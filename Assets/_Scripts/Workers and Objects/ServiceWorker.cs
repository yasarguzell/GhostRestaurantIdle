using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ServiceWorker : MonoBehaviour
{
    [Header("References")]
    public BetweenAreasController _betweenAreasController;
    public WorkerState WorkerState;
    public Image TimerImage;
    private ServiceAreaController _areaController;
    [SerializeField] private float _movementSpeed;
    private Vector3 _idlePosition;
    private NavMeshAgent _navMeshAgent;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(ServiceAreaController areaController, float movementSpeed, Vector3 idlePosition, BetweenAreasController betweenAreasController)
    {
        _movementSpeed = movementSpeed;
        _areaController = areaController;
        _idlePosition = idlePosition;
        _betweenAreasController = betweenAreasController;
    }

    public IEnumerator GetFoodCoroutine(Vector3 customerPosition)
    {
        // find tray with food
        ReadyFoodTray tray = null;
        yield return StartCoroutine(FindReadyFoodCoroutine((foundTray) => tray = foundTray));

        // Move to tray
        yield return StartCoroutine(MoveToPosition(tray.transform.position));

        // get food
        tray.IsInUse = false;
        tray.IsSelectedByWorker = false;

        // move back to customer
        yield return StartCoroutine(MoveToPosition(customerPosition));

        // drop food

        WorkerState = WorkerState.idle;

    }

    public IEnumerator ReturnDirtyDishCoroutine(Vector3 seatPosition, Table table, int seatIndex)
    {
        // Move to seat
        yield return StartCoroutine(MoveToPosition(seatPosition));

        // take dish
        table.GetCustomer(seatIndex);// call for new customer on table

        // drop the dish
        yield return StartCoroutine(MoveToPosition(_betweenAreasController._dirtyDishDropTray.transform.position));
        _betweenAreasController._dirtyDishDropTray.MoveDirtyDish();
        WorkerState = WorkerState.idle;

    }

    public void StartReturningDirtyDishMission(Vector3 seatPosition, Table table, int seatIndex)
    {
        StartCoroutine(ReturnDirtyDishCoroutine(seatPosition, table, seatIndex));
    }

    private IEnumerator FindReadyFoodCoroutine(System.Action<ReadyFoodTray> callback)
    {
        ReadyFoodTray tray;
        while (!_betweenAreasController.TryGetReadyFood(out tray))
        {
            yield return null;
        }
        callback(tray);
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        _navMeshAgent.SetDestination(targetPosition);

        while (_navMeshAgent.pathPending || _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            yield return null;
        }
    }

}
