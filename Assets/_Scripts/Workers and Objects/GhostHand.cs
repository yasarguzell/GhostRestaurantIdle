using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GhostHand : MonoBehaviour
{
    public BetweenAreasController _betweenAreasController;
    [SerializeField] private float _movementSpeed;

    public void Init(float movementSpeed, BetweenAreasController betweenAreasController)
    {
        _movementSpeed = movementSpeed;
        _betweenAreasController = betweenAreasController;
    }

    public void StartMoveDirtyDishMission(Vector3 dirtyDishDropTrayWorkingSpot, Vector3 waitPosition)
    {
        StartCoroutine(MoveDirtyDishMission(dirtyDishDropTrayWorkingSpot, waitPosition));
    }

    private IEnumerator MoveDirtyDishMission(Vector3 dirtyDishDropTrayWorkingSpot, Vector3 waitPosition)
    {
        // rise to tray
        yield return StartCoroutine(MoveToPosition(dirtyDishDropTrayWorkingSpot));

        // get the dish

        // Move to wait position
        yield return StartCoroutine(MoveToPosition(waitPosition));

        // Find dirty dish tray
        DirtyDishesTray tray = null;
        yield return StartCoroutine(FindDirtyDishTrayCoroutine((foundTray) => tray = foundTray));

        // Move to tray
        yield return StartCoroutine(MoveToPosition(tray.transform.position));

        tray.AddDirtyDish();

        // disappear
    }

    private IEnumerator FindDirtyDishTrayCoroutine(System.Action<DirtyDishesTray> callback)
    {
        DirtyDishesTray tray;
        while (!_betweenAreasController.TryGetAvailableDirtyDishTray(out tray))
        {
            yield return null;
        }
        callback(tray);
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        yield return transform.DOMove(targetPosition, _movementSpeed).WaitForCompletion();
    }
}
