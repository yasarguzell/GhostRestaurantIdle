using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
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

    public void UpdateButton()
    {
        Debug.Log("UpdateButton");
        
        soDataHolder.dataHolder.valueB = 10f;
        Debug.Log("Updated valueB to " + soDataHolder.dataHolder.valueB);
       
    }
}
