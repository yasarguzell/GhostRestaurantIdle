using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestUpdateData : MonoBehaviour
{
  // EVENT
  public static TestUpdateData Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
  }

  public UnityAction<float> onSendData=delegate{};
}
