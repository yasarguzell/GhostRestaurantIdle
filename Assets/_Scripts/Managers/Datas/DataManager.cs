using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // update ref update manager
    SODataHolder soDataHolder;


    void Awake()
    {
        soDataHolder = GetDataHolder();
    }
    void Start()
    {
        CoreGameSignals.Instance.onDataValueX += GetData;

    }

    private SODataHolder GetDataHolder()
    {

        return Resources.Load<SODataHolder>("Datas/SODataHolder");
    }

    private void GetData(float arg0)
    {

        if (soDataHolder != null)
        {
            soDataHolder.dataHolder.valueB += arg0;
        }
    }



}
