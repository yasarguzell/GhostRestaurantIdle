using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class DishwashingWorker : MonoBehaviour
{
    public WorkerState WorkerState;
    public Image TimerImage;
    private DishwashingAreaController _areaController;
    [SerializeField] private float _cleaningTime;
    [SerializeField] private float _movementSpeed;
    private Coroutine _cleaningTask;
    private Vector3 _idlePosition;

    private void Awake()
    {
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(DishwashingAreaController areaController, float cleaningTime, float movementSpeed, Vector3 idlePosition)
    {
        _cleaningTime = cleaningTime;
        _movementSpeed = movementSpeed;
        _areaController = areaController;
        _idlePosition = idlePosition;
    }

    private IEnumerator Clean()
    {
        float cleaningTime = _cleaningTime;
        float elapsedTime = 0;
        TimerImage.fillAmount = 0;
        while (elapsedTime < cleaningTime)
        {
            elapsedTime += Time.deltaTime;
            TimerImage.fillAmount = elapsedTime / cleaningTime;
            yield return null;
        }
        TimerImage.fillAmount = 0;
    }

    public void StartMission(Vector3 dirtyDishPosition, Vector3 cleanDishPosition)
    {
        StartCoroutine(CleaningMission(dirtyDishPosition, cleanDishPosition));
        // Move to dish
        // Take the dish
        // Go to available dishwashing machine
        // After finishing move to clean dish tray
        // Drop tray
    }

    private IEnumerator CleaningMission(Vector3 dirtyDishPosition, Vector3 cleanDishPosition)
    {
        // Move to dish
        yield return StartCoroutine(MoveToPosition(transform.position, dirtyDishPosition, _movementSpeed));

        // Move to idle position
        yield return StartCoroutine(MoveToPosition(transform.position, _idlePosition, _movementSpeed));

        // Find dishwasher
        DishwashingMachine machine = null;
        yield return StartCoroutine(FindDishwasherCoroutine((foundMachine) => machine = foundMachine));

        // Move to dishwasher
        yield return StartCoroutine(MoveToPosition(transform.position, machine.WorkingSpot.position, _movementSpeed));

        // Start cleaning
        yield return StartCoroutine(Clean());

        // Free machine
        machine.IsInUse = false;

        // Move to clean dishes tray
        yield return StartCoroutine(MoveToPosition(transform.position, cleanDishPosition, _movementSpeed));

        // Drop dish!!!!!!!!!!!!

        WorkerState = WorkerState.idle;
    }

    private IEnumerator MoveToPosition(Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }
    }

    private IEnumerator FindDishwasherCoroutine(System.Action<DishwashingMachine> callback)
    {
        DishwashingMachine machine;
        while (!_areaController.TryGetAvailableDishwashingMachine(out machine))
        {
            yield return null;
        }
        callback(machine);
    }

}
