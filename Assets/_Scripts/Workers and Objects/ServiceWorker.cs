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
    public Transform HandPosition;
    public Image TimerImage;
    private ServiceAreaController _areaController;
    private Vector3 _idlePosition;
    private NavMeshAgent _navMeshAgent;
    private Coroutine _moveToIdleCoroutine;
    public Animator _animator;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(ServiceAreaController areaController, float movementSpeed, Vector3 idlePosition, BetweenAreasController betweenAreasController)
    {
        _navMeshAgent.speed = movementSpeed;
        _areaController = areaController;
        _idlePosition = idlePosition;
        _betweenAreasController = betweenAreasController;
    }

    public IEnumerator GetFoodCoroutine(Vector3 customerPosition, Customer customer, Vector3 platePosition, Table table, int seatIndex)
    {
        if (_moveToIdleCoroutine != null)
            StopCoroutine(_moveToIdleCoroutine);
        // find tray with food
        ReadyFoodTray tray = null;
        while (!_betweenAreasController.TryGetReadyFood(out tray))
        {
            customer.RestartOrder();
            WorkerState = WorkerState.idle;
            yield break;
        }

        //yield return StartCoroutine(FindReadyFoodCoroutine((foundTray) => tray = foundTray));
        var plate = tray.PlateOnIt;

        // Move to tray
        yield return StartCoroutine(MoveToPosition(tray.transform.position));
        // get food

        // Move dish to hand and set as child of it 
        plate.transform.parent = HandPosition;
        yield return StartCoroutine(plate.MoveToLocalPosition(HandPosition.position, 0.5f));

        tray.IsInUse = false;
        tray.IsSelectedByServer = false;
        tray.PlateOnIt = null;

        // move back to customer
        yield return StartCoroutine(MoveToPosition(customerPosition));
        // drop food on table
        yield return StartCoroutine(plate.MoveToPosition(platePosition, 0.5f));
        plate.transform.parent = null;

        table.Plates[seatIndex] = plate;

        //yield return StartCoroutine(MoveToPosition(_idlePosition));
        // drop food
        _moveToIdleCoroutine = StartCoroutine("MoveToIdlePos");
        WorkerState = WorkerState.idle;

    }

    private IEnumerator MoveToIdlePos()
    {
        yield return StartCoroutine(MoveToPosition(_idlePosition));
    }

    public IEnumerator ReturnDirtyDishCoroutine(Vector3 seatPosition, Table table, int seatIndex)
    {
        if (_moveToIdleCoroutine != null)
            StopCoroutine(_moveToIdleCoroutine);
        // Move to seat
        yield return StartCoroutine(MoveToPosition(seatPosition));
        MoneyManagement.Instance.UpdateBooCoin(150);
        Plate plate = table.Plates[seatIndex];
        plate.transform.parent = HandPosition;
        yield return StartCoroutine(plate.MoveToLocalPosition(HandPosition.position, 0.5f));
        table.Plates[seatIndex] = null;
        //!!!!
        // take dish
        table.GetCustomer(seatIndex);// call for new customer on table

        // drop the dish
        yield return StartCoroutine(MoveToPosition(_betweenAreasController._dirtyDishDropTray._workingSpot.position));
        yield return StartCoroutine(plate.MoveToPosition(_betweenAreasController._dirtyDishDropTray.ConveyerStart.position, 1));
        plate.transform.parent = null;
        _betweenAreasController._dirtyDishDropTray.MoveDirtyDish(plate);
        _moveToIdleCoroutine = StartCoroutine("MoveToIdlePos");
        WorkerState = WorkerState.idle;

    }

    public void StartReturningDirtyDishMission(Vector3 seatPosition, Table table, int seatIndex)
    {
        StartCoroutine(ReturnDirtyDishCoroutine(seatPosition, table, seatIndex));
    }

    //private IEnumerator FindReadyFoodCoroutine(System.Action<ReadyFoodTray> callback)
    //{
    //    ReadyFoodTray tray;

    //    callback(tray);
    //}

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        _animator.SetBool("walking", true);

        _navMeshAgent.SetDestination(targetPosition);

        while (_navMeshAgent.pathPending || _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            yield return null;
        }
        _animator.SetBool("walking", false);

    }
    public void UpdateDatas(float amount)
    {
        _navMeshAgent.speed = amount;

    }


}
