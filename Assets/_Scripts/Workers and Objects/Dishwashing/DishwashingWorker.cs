using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class DishwashingWorker : MonoBehaviour
{
    [Header("References")]
    public BetweenAreasController _betweenAreasController;
    public WorkerState WorkerState;
    public Image TimerImage;
    private DishwashingAreaController _areaController;
    [SerializeField] private float _cleaningTime;
    [SerializeField] private float _movementSpeed;
    private Vector3 _idlePosition;

    private void Awake()
    {
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(DishwashingAreaController areaController, float cleaningTime, float movementSpeed, Vector3 idlePosition, BetweenAreasController betweenAreasController)
    {
        _cleaningTime = cleaningTime;
        _movementSpeed = movementSpeed;
        _areaController = areaController;
        _idlePosition = idlePosition;
        _betweenAreasController = betweenAreasController;
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

    public void StartMission(Vector3 dirtyDishPosition, DirtyDishesTray dirtyDishesTray)
    {
        StartCoroutine(CleaningMission(dirtyDishPosition, dirtyDishesTray));
    }

    private IEnumerator CleaningMission(Vector3 dirtyDishPosition, DirtyDishesTray dirtyDishesTray)
    {
        // Move to dish
        yield return StartCoroutine(MoveToPosition(dirtyDishPosition));

        // Free tray
        dirtyDishesTray.IsInUse = false;

        // Move to idle position
        yield return StartCoroutine(MoveToPosition(_idlePosition));

        // Find dishwasher
        DishwashingMachine machine = null;
        yield return StartCoroutine(FindDishwasherCoroutine((foundMachine) => machine = foundMachine));

        // Move to dishwasher
        yield return StartCoroutine(MoveToPosition(machine.WorkingSpot.position));

        // Start cleaning
        yield return StartCoroutine(Clean());

        // Free machine
        machine.IsInUse = false;

        // Find clean tray
        CleanDishesTray tray = null;
        yield return StartCoroutine(FindCleanDishTrayCoroutine((foundTray) => tray = foundTray));

        // Move to clean dishes tray
        yield return StartCoroutine(MoveToPosition(tray.transform.position));

        // Drop dish!!!!!!!!!!!!
        tray.AddCleanDish();
        WorkerState = WorkerState.idle;
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        yield return transform.DOMove(targetPosition, _movementSpeed).WaitForCompletion();
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

    private IEnumerator FindCleanDishTrayCoroutine(System.Action<CleanDishesTray> callback)
    {
        CleanDishesTray tray;
        while (!_betweenAreasController.TryGetAvailableCleanDishTray(out tray))
        {
            yield return null;
        }
        callback(tray);
    }

}
