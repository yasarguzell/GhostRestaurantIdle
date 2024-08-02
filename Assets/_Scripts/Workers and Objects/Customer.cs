using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [Header("References")]
    public ServiceAreaController _areaController;
    public Image TimerImage;
    [SerializeField] private float _eatingTime;
    private NavMeshAgent _navMeshAgent;
    private Coroutine coroutine;
    Vector3 seatPosition;
    Vector3 getOutPosition;
    Table tableReferance; int
        seatIndex;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimerImage.fillAmount = 0;
    }

    public void Init(ServiceAreaController areaController, float eatingTime, float movementSpeed)
    {
        _areaController = areaController;
        _eatingTime = eatingTime;
        _navMeshAgent.speed = movementSpeed;
    }

    public void StartEatingMission(Vector3 seatPosition, Vector3 getOutPosition, Table tableReferance, int seatIndex, float waitingTime)
    {
        this.seatPosition = seatPosition;
        this.getOutPosition = getOutPosition;
        this.tableReferance = tableReferance;
        this.seatIndex = seatIndex;
        coroutine = StartCoroutine(EatingMission(seatPosition, getOutPosition, tableReferance, seatIndex, waitingTime));
    }


    private IEnumerator EatingMission(Vector3 seatPosition, Vector3 getOutPosition, Table tableReference, int seatIndex, float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        // Go to clean dish
        // return to idle
        // find available cooktop
        // go to cooktop
        // cook
        // go to ready food tray
        // Move to dish
        yield return StartCoroutine(MoveToPosition(seatPosition));
        // request server
        ServiceWorker worker = null;
        yield return StartCoroutine(FindAvailableWorkerCoroutine((foundWorker) => worker = foundWorker));
        // request food

        yield return StartCoroutine(worker.GetFoodCoroutine(transform.position, this, tableReferance.GetPlatePosition(seatIndex), tableReferance, seatIndex));

        yield return StartCoroutine(Eat());
        tableReferance.Plates[seatIndex].ChangePlateState(PlateState.dirty);
        // delete food and spawn dirty dish

        // call for dirty dish pickup
        tableReference.CallForDirtyDishPickUp(seatIndex);

        yield return StartCoroutine(MoveToPosition(getOutPosition));


        Destroy(gameObject);
    }
    public void RestartOrder()
    {
        StopCoroutine(coroutine);
        StartEatingMission(seatPosition, getOutPosition, tableReferance, seatIndex, 2);
    }

    private IEnumerator FindAvailableWorkerCoroutine(System.Action<ServiceWorker> callback)
    {
        ServiceWorker worker;
        while (!_areaController.TryGetAvailableWorker(out worker))
        {
            yield return new WaitForSeconds(1);
        }
        callback(worker);
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        _navMeshAgent.SetDestination(targetPosition);

        while (_navMeshAgent.pathPending || _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            yield return null;

        }

    }

    private IEnumerator Eat()
    {
        float eatingTime = _eatingTime;
        float elapsedTime = 0;
        TimerImage.fillAmount = 0;
        while (elapsedTime < eatingTime)
        {
            elapsedTime += Time.deltaTime;
            TimerImage.fillAmount = elapsedTime / eatingTime;
            yield return null;
        }
        TimerImage.fillAmount = 0;
    }
}
