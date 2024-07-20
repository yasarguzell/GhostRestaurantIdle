using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventSubscriber : MonoBehaviour
{
  public  void OnClick()
    {
        Debug.Log("Clicked");
        TestUpdateData.Instance.onSendData.Invoke(45F);
    }
}
