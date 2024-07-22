using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreUISignals : MonoBehaviour
{
  public UnityAction onOpenPausePanel = delegate { };
  public UnityAction onClosePausePanel= delegate { };






public UnityAction<byte> onRoomUIIndex = delegate { };
public static CoreUISignals Instance { get; set; }
void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    else
    {
        Destroy(this.gameObject);
    }
}
}
