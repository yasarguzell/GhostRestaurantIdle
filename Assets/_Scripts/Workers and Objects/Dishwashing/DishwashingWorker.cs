using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class DishwashingWorker : MonoBehaviour
{
    [Header("References")]
    public BetweenAreasController _betweenAreasController;
    public Transform HandPosition;
    public WorkerState WorkerState;
    public Image TimerImage;
    private DishwashingAreaController _areaController;
    [SerializeField] private float _cleaningTime;
    private Vector3 _idlePosition;
    private NavMeshAgent _navMeshAgent;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(DishwashingAreaController areaController, float cleaningTime, float movementSpeed, Vector3 idlePosition, BetweenAreasController betweenAreasController)
    {
        _cleaningTime = cleaningTime;
        _navMeshAgent.speed = movementSpeed; _areaController = areaController;
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

        var plate = dirtyDishesTray.PlateOnIt;

        // Move dish to hand and set as child of it 
        yield return StartCoroutine(plate.MoveToPosition(HandPosition.position, 0.5f));
        plate.transform.parent = HandPosition;

        // Free tray
        dirtyDishesTray.IsInUse = false;
        dirtyDishesTray.PlateOnIt = null;

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

        // Move dish to tray and set child of global 
        yield return StartCoroutine(plate.MoveToPosition(tray.transform.TransformPoint(Vector3.up * 0.5f), 0.5f));
        plate.transform.parent = null;
        tray.PlateOnIt = plate;

        tray.AddCleanDish();
        WorkerState = WorkerState.idle;
        yield return StartCoroutine(MoveToPosition(_idlePosition));
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        _navMeshAgent.SetDestination(targetPosition);

        while (_navMeshAgent.pathPending || _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            yield return null;
        }
    }

    private IEnumerator FindDishwasherCoroutine(System.Action<DishwashingMachine> callback)
    {
        DishwashingMachine machine;
        while (!_areaController.TryGetAvailableDishwashingMachine(out machine))
        {
            yield return new WaitForSeconds(1);
        }
        callback(machine);
    }

    private IEnumerator FindCleanDishTrayCoroutine(System.Action<CleanDishesTray> callback)
    {
        CleanDishesTray tray;
        while (!_betweenAreasController.TryGetAvailableCleanDishTray(out tray))
        {
            yield return new WaitForSeconds(1);
        }
        callback(tray);
    }

    public void UpdateDatas(float amount, float value)
    {
        _navMeshAgent.speed = amount;
        _cleaningTime = value;
    }

}
