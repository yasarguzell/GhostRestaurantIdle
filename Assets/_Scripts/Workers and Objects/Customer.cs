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
    [SerializeField] private float _movementSpeed;
    private Vector3 _idlePosition;
    private NavMeshAgent _navMeshAgent;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimerImage.fillAmount = 0;
    }

    public void Init(ServiceAreaController areaController, float eatingTime, float movementSpeed)
    {
        _areaController = areaController;
        _eatingTime = eatingTime;
        _movementSpeed = movementSpeed;
    }

    public void StartEatingMission(Vector3 seatPosition, Vector3 getOutPosition, Table tableReferance, int seatIndex)
    {
        StartCoroutine(EatingMission(seatPosition, getOutPosition, tableReferance, seatIndex));
    }


    private IEnumerator EatingMission(Vector3 seatPosition, Vector3 getOutPosition, Table tableReference, int seatIndex)
    {
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
        yield return StartCoroutine(worker.GetFoodCoroutine(transform.position));

        yield return StartCoroutine(Eat());

        // call for dirty dish pickup
        tableReference.CallForDirtyDishPickUp(seatIndex);

        yield return StartCoroutine(MoveToPosition(getOutPosition));

        Destroy(gameObject);
    }

    private IEnumerator FindAvailableWorkerCoroutine(System.Action<ServiceWorker> callback)
    {
        ServiceWorker worker;
        while (!_areaController.TryGetAvailableWorker(out worker))
        {
            yield return null;
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
