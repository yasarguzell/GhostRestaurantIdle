using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventSubscriber : MonoBehaviour
{
  //button
  public  void OnClick()
    {
        Debug.Log("Clicked");
        CoreGameSignals.Instance.onDataValueX?.Invoke(45F);
    }
}
