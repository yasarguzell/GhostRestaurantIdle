using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Plate : MonoBehaviour
{
    public GameObject _croissantPlate;

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
        switch (state)
        {
            case PlateState.dirty:
                _croissantPlate.SetActive(false);
                break;
            case PlateState.clean:
                _croissantPlate.SetActive(false);
                break;
            case PlateState.food:
                _croissantPlate.SetActive(true);
                break;
        }
    }
}

public enum PlateState { dirty, clean, food }
