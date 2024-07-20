using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    SODataHolder soDataHolder;
    float value;
    
    void Awake()
    {
        soDataHolder = GetDataHolder();
    }
    void Start()
    {
        TestUpdateData.Instance.onSendData+=GetData;
        
    }

    private void GetData(float arg0)
{
    value = arg0;
    if (soDataHolder != null)
    {
        soDataHolder.dataHolder.valueB = arg0;
    }
}


    private SODataHolder GetDataHolder()
    {
        
        return Resources.Load<SODataHolder>("Datas/SODataHolder");
    }

   void Update()
   {
    
    value=soDataHolder.dataHolder.valueB;
    
    Debug.Log(value);
   }
}
