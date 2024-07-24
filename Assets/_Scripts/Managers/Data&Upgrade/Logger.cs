using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    // npc player vb controllerı
    [SerializeField] MoneyManagement moneyManagement;
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
            Debug.Log("valueX: " + soDataHolder.dataHolder.valueX);
            Debug.Log("valueY: " + soDataHolder.dataHolder.valueY);
            Debug.Log("valueZ: " + soDataHolder.dataHolder.valueZ);
            Debug.Log("valueA: " + soDataHolder.dataHolder.valueA);
            Debug.Log("valueB: " + soDataHolder.dataHolder.valueB);
        }
        float test2=test*soDataHolder.dataHolder.valueX;
        Debug.Log(test2);
    }

    public void EarnTestMoney()
    {
        moneyManagement.UpdateBooCoin(150);
    }
}
