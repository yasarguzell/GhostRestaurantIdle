using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Plate : MonoBehaviour
{
    public IEnumerator MoveToPosition(Vector3 targetPosition, float time)
    {
        yield return transform.DOMove(targetPosition, time).WaitForCompletion();
    }
    public IEnumerator MoveToLocalPosition(Vector3 targetPosition, float time)
    {
        yield return transform.DOLocalMove(Vector3.zero, time).WaitForCompletion();
    }


    public void ChangePlateState(PlateState state)
    {
        // According to state change the plate mesh
    }
}

public enum PlateState { dirty, clean, food }
