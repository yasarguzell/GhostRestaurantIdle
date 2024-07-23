using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishDropTray : MonoBehaviour
{
    public BetweenAreasController _areaController;
    public GameObject _ghostHand;
    public Transform _workingSpot;
    public float _ghostHandMovementSpeed;

    [ContextMenu("move dirty dish")]
    public void MoveDirtyDish()
    {
        // spawn hand
        GhostHand hand = Instantiate(_ghostHand, _workingSpot.position + 2 * Vector3.down, Quaternion.identity).GetComponent<GhostHand>();
        hand.Init(_ghostHandMovementSpeed, _areaController);
        hand.StartMoveDirtyDishMission(_workingSpot.position, _workingSpot.position);
    }
}
