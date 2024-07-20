using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    SODataHolder soDataHolder;

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
            Debug.Log("valueB: " + soDataHolder.dataHolder.valueB);
        }
    }
}
