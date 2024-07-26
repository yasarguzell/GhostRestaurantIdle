using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class DirtyDishDropTray : MonoBehaviour
{
    public BetweenAreasController _areaController;
    public BetweenAreasController _betweenAreasController;
    public Transform ConveyerEnd;
    public Transform ConveyerStart;
    public GameObject _ghostHand;
    public Transform _workingSpot;
    public float _ghostHandMovementSpeed;

    [ContextMenu("move dirty dish")]
    public void MoveDirtyDish(Plate plate)
    {
        StartCoroutine(MoveDish(plate));
    }

    private IEnumerator MoveDish(Plate plate)
    {
        yield return StartCoroutine(plate.MoveToPosition(ConveyerEnd.position, 4));

        DirtyDishesTray tray = null;
        yield return StartCoroutine(FindDirtyDishTrayCoroutine((foundTray) => tray = foundTray));

        yield return StartCoroutine(plate.MoveToPosition(tray.PlatePosition, 0.3f));
        tray.PlateOnIt = plate;
        tray.AddDirtyDish();
    }

    private IEnumerator FindDirtyDishTrayCoroutine(System.Action<DirtyDishesTray> callback)
    {
        DirtyDishesTray tray;
        while (!_betweenAreasController.TryGetAvailableDirtyDishTray(out tray))
        {
            yield return new WaitForSeconds(0.1f);
        }
        callback(tray);
    }
}
