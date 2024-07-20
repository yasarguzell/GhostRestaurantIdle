using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // update ref
    SODataHolder soDataHolder;
    
    
    void Awake()
    {
        soDataHolder = GetDataHolder();
    }
    void Start()
    {
        CoreGameSignals.Instance.onDataValueX+=GetData;
        
    }

    private void GetData(float arg0)
{
   
    if (soDataHolder != null)
    {
        soDataHolder.dataHolder.valueB += arg0;
    }
}


    private SODataHolder GetDataHolder()
    {
        
        return Resources.Load<SODataHolder>("Datas/SODataHolder");
    }

  
}
