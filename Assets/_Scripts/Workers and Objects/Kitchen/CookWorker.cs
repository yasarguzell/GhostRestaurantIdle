using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using DG.Tweening;

public class CookWorker : MonoBehaviour
{
    [Header("References")]
    public BetweenAreasController _betweenAreasController;
    public Transform HandPosition;
    public WorkerState WorkerState;
    public Image TimerImage;
    private KitchenAreaController _areaController;
    [SerializeField] private float _cookingTime;
    private Vector3 _idlePosition;
    private NavMeshAgent _navMeshAgent;
    public Animator _animator;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(KitchenAreaController areaController, float cookingTime, float movementSpeed, Vector3 idlePosition, BetweenAreasController betweenAreasController)
    {
        _cookingTime = cookingTime;
        _navMeshAgent.speed = movementSpeed;
        _areaController = areaController;
        _idlePosition = idlePosition;
        _betweenAreasController = betweenAreasController;
    }

    public void StartCookingMission(Vector3 cleanDishPosition, CleanDishesTray cleanDishesTray)
    {
        StartCoroutine(CookingMission(cleanDishPosition, cleanDishesTray));
    }


    private IEnumerator CookingMission(Vector3 cleanDishPosition, CleanDishesTray cleanDishesTray)
    {
        // Go to clean dish
        // return to idle
        // find available cooktop
        // go to cooktop
        // cook
        // go to ready food tray
        // Move to dish
        yield return StartCoroutine(MoveToPosition(cleanDishPosition));

        var plate = cleanDishesTray.PlateOnIt;

        // Move dish to hand and set as child of it 
        plate.transform.parent = HandPosition;
        yield return StartCoroutine(plate.MoveToLocalPosition(HandPosition.position, 0.5f));

        // Free tray
        cleanDishesTray.IsInUse = false;
        cleanDishesTray.PlateOnIt = null;

        // Find cooktop
        Cooktop cooktop = null;
        yield return StartCoroutine(FindCooktopCoroutine((foundMachine) => cooktop = foundMachine));

        // Move to cooktop
        yield return StartCoroutine(MoveToPosition(cooktop.WorkingSpot.position));

        // Start cooking
        yield return StartCoroutine(Cook());

        plate.ChangePlateState(PlateState.food);

        // Free cooktop
        cooktop.IsInUse = false;

        // Find ready food tray
        ReadyFoodTray tray = null;
        yield return StartCoroutine(FindReadyFoodTrayCoroutine((foundTray) => tray = foundTray));

        // Move to ready food tray
        yield return StartCoroutine(MoveToPosition(tray.transform.position));

        yield return StartCoroutine(plate.MoveToPosition(tray.transform.TransformPoint(Vector3.up * 0.5f), 0.5f));
        plate.transform.parent = null;
        tray.PlateOnIt = plate;

        tray.IsInUse = true;
        tray.IsSelectedByCook = false;

        // Drop food!!!!!!!!!!!!
        WorkerState = WorkerState.idle;
        //yield return StartCoroutine(MoveToPosition(_idlePosition));
    }

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

    private IEnumerator Cook()
    {
        float cookingTime = _cookingTime;
        float elapsedTime = 0;
        TimerImage.fillAmount = 0;
        _animator.SetBool("working", true);

        while (elapsedTime < cookingTime)
        {
            elapsedTime += Time.deltaTime;
            TimerImage.fillAmount = elapsedTime / cookingTime;
            yield return null;
        }
        TimerImage.fillAmount = 0;
        _animator.SetBool("working", false);

    }

    private IEnumerator FindReadyFoodTrayCoroutine(System.Action<ReadyFoodTray> callback)
    {
        ReadyFoodTray tray;
        while (!_betweenAreasController.TryGetAvailableReadyFoodTray(out tray))
        {
            yield return new WaitForSeconds(1);
        }
        callback(tray);
    }

    private IEnumerator FindCooktopCoroutine(System.Action<Cooktop> callback)
    {
        Cooktop cooktop;
        while (!_areaController.TryGetAvailableCooktop(out cooktop))
        {
            yield return new WaitForSeconds(1);
        }
        callback(cooktop);
    }
    public void UpdateDatas(float movementSpeed, float cookSpeed)
    {
        _navMeshAgent.speed = movementSpeed;
        _cookingTime = cookSpeed;
    }

}
