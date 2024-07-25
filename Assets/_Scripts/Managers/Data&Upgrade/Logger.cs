using UnityEngine;

public class Logger : MonoBehaviour
{
    // npc player vb controllerı
    [SerializeField] MoneyManagement moneyManagement;
    SODataHolder soDataHolder;
    float testV=1;
    //float test=5;

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
            Debug.Log("chefCookSpeedUpgrade: " + soDataHolder.dataHolder.chefCookSpeedUpgrade);
            Debug.Log("waitersSpeedUpgrade: " + soDataHolder.dataHolder.waitersSpeedUpgrade);
            Debug.Log("washingWorkerSpeed: " + soDataHolder.dataHolder.washingWorkerSpeed);
            Debug.Log("upgradeWashSpeed: " + soDataHolder.dataHolder.upgradeWashSpeed);
            Debug.Log("chefMovementSpeed: " + soDataHolder.dataHolder.chefMovementSpeed);
        }
        testV=soDataHolder.dataHolder.chefCookSpeedUpgrade*5f;
        Debug.Log(testV);
      
    }

    public void EarnTestMoney()
    {
        moneyManagement.UpdateBooCoin(150);
    }
}
