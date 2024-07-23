using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CookWorker : MonoBehaviour
{
    [Header("References")]
    public BetweenAreasController _betweenAreasController;
    public WorkerState WorkerState;
    public Image TimerImage;
    private KitchenAreaController _areaController;
    [SerializeField] private float _cookingTime;
    [SerializeField] private float _movementSpeed;
    private Vector3 _idlePosition;

    private void Awake()
    {
        TimerImage.fillAmount = 0;
        WorkerState = WorkerState.idle;
    }

    public void Init(KitchenAreaController areaController, float cleaningTime, float movementSpeed, Vector3 idlePosition, BetweenAreasController betweenAreasController)
    {
        _cookingTime = cleaningTime;
        _movementSpeed = movementSpeed;
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

        // Free tray
        cleanDishesTray.IsInUse = false;

        // Move to idle position
        yield return StartCoroutine(MoveToPosition(_idlePosition));

        // Find cooktop
        Cooktop cooktop = null;
        yield return StartCoroutine(FindCooktopCoroutine((foundMachine) => cooktop = foundMachine));

        // Move to cooktop
        yield return StartCoroutine(MoveToPosition(cooktop.WorkingSpot.position));

        // Start cooking
        yield return StartCoroutine(Cook());

        // Free cooktop
        cooktop.IsInUse = false;

        // Find clean tray
        ReadyFoodTray tray = null;
        yield return StartCoroutine(FindReadyFoodTrayCoroutine((foundTray) => tray = foundTray));

        // Move to ready food tray
        yield return StartCoroutine(MoveToPosition(tray.transform.position));

        // Drop food!!!!!!!!!!!!

        WorkerState = WorkerState.idle;
    }

    private IEnumerator Cook()
    {
        float cookingTime = _cookingTime;
        float elapsedTime = 0;
        TimerImage.fillAmount = 0;
        while (elapsedTime < cookingTime)
        {
            elapsedTime += Time.deltaTime;
            TimerImage.fillAmount = elapsedTime / cookingTime;
            yield return null;
        }
        TimerImage.fillAmount = 0;
    }

    private IEnumerator FindReadyFoodTrayCoroutine(System.Action<ReadyFoodTray> callback)
    {
        ReadyFoodTray tray;
        while (!_betweenAreasController.TryGetAvailableReadyFoodTray(out tray))
        {
            yield return null;
        }
        callback(tray);
    }

    private IEnumerator FindCooktopCoroutine(System.Action<Cooktop> callback)
    {
        Cooktop cooktop;
        while (!_areaController.TryGetAvailableCooktop(out cooktop))
        {
            yield return null;
        }
        callback(cooktop);
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        yield return transform.DOMove(targetPosition, _movementSpeed).WaitForCompletion();
    }

}
