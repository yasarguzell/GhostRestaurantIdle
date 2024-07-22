using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    // npc player vb controllerı
    SODataHolder soDataHolder;
    float test=5;

    void Awake()
    {
        soDataHolder = GetDataHolder();
    }

    private SODataHolder GetDataHolder()
    {
         return Resources.Load<SODataHolder>("Datas/SODataHolder");
    }

    void Update()
    {
        if (soDataHolder != null)
        {
            Debug.Log("valueB: " + soDataHolder.dataHolder.valueX);
        }
        float test2=test*soDataHolder.dataHolder.valueX;
        Debug.Log(test2);
    }
}
