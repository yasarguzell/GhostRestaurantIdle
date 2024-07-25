using UnityEngine;

public class DataManager : MonoBehaviour
{
    // update ref update manager
    SODataHolder soDataHolder;


    void Awake()
    {
        soDataHolder = GetDataHolder();
        
    }
    private SODataHolder GetDataHolder()
    {
        return Resources.Load<SODataHolder>("Datas/SODataHolder");
    }
   
    void OnEnable()
    {
        Subscribe();
    }
    void OnDisable()
    {
        UnSubscribe();
    }

    void Subscribe()
    {
        CoreGameSignals.Instance.onDataUpgradeChefCookSpeed += onGetDataX;
        CoreGameSignals.Instance.onDataUpgradeWaitersSpeed += onGetDataY;
        CoreGameSignals.Instance.onDataUpgradeWashingWorkerSpeed += onGetDataZ;
        CoreGameSignals.Instance.onDataUpgradeWashSpeed += onGetDataA;
        CoreGameSignals.Instance.onDataUpgradeChefMovementSpeed += onGetDataB;

    }
    private void UnSubscribe()
    {
        CoreGameSignals.Instance.onDataUpgradeChefCookSpeed -= onGetDataX;
        CoreGameSignals.Instance.onDataUpgradeWaitersSpeed -= onGetDataY;
        CoreGameSignals.Instance.onDataUpgradeWashingWorkerSpeed -= onGetDataZ;
        CoreGameSignals.Instance.onDataUpgradeWashSpeed -= onGetDataA;
        CoreGameSignals.Instance.onDataUpgradeChefMovementSpeed -= onGetDataB;
    }


    private void onGetDataB(float value)
    {
        soDataHolder.dataHolder.chefMovementSpeed += value;  
        CoreGameSignals.Instance.onDataChanged?.Invoke();      
    }

    private void onGetDataA(float value)
    {
        soDataHolder.dataHolder.upgradeWashSpeed += value;
         CoreGameSignals.Instance.onDataChanged?.Invoke();  
    }

    private void onGetDataZ(float value)
    {
        soDataHolder.dataHolder.washingWorkerSpeed += value;
         CoreGameSignals.Instance.onDataChanged?.Invoke();  
    }

    private void onGetDataY(float value)
    {
         soDataHolder.dataHolder.waitersSpeedUpgrade += value;
          CoreGameSignals.Instance.onDataChanged?.Invoke();  
    }

    private void onGetDataX(float value)
    {
         soDataHolder.dataHolder.chefCookSpeedUpgrade += value;
        CoreGameSignals.Instance.onDataChanged?.Invoke();  
    }


    



}
