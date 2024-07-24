using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
   UpgradeTable upgradeTable;
    UpgradeCost upgradeCost;
    SOMoneyData soMoneyData;
    long costX;
    long costY;
    long costZ;
    long costA;
    long costB;


    void Awake()
    {
        upgradeTable = GetComponent<UpgradeTable>();
        upgradeCost = GetComponent<UpgradeCost>();
        soMoneyData=GetMoneyData();

       
    }
  
    private SOMoneyData GetMoneyData()
    {
        return Resources.Load<SOMoneyData>("Datas/MoneyData");
    }
    void Start()
    {
    SendCostText();
    }
    void SendCostText()
    {
         costX=(long)upgradeCost.CostValuesX[upgradeCost.CostValueXIndex];
         costY=(long)upgradeCost.CostValuesY[upgradeCost.CostValueYIndex];
         costZ=(long)upgradeCost.CostValuesZ[upgradeCost.CostValueZIndex];
         costA=(long)upgradeCost.CostValuesA[upgradeCost.CostValueAIndex];
         costB=(long)upgradeCost.CostValuesB[upgradeCost.CostValueBIndex];

        CoreUISignals.Instance.onUpgradeCostText?.Invoke(0,costX);
        
        CoreUISignals.Instance.onUpgradeCostText?.Invoke(1,costY);
        
        CoreUISignals.Instance.onUpgradeCostText?.Invoke(2,costZ);
        
        CoreUISignals.Instance.onUpgradeCostText?.Invoke(3,costA);
        
        CoreUISignals.Instance.onUpgradeCostText?.Invoke(4,costB);
        Debug.Log("SEND COST");
        
       
    }

  public void UpgradeValueX()
{
    if (!upgradeCost.CostValuesX.ContainsKey(upgradeCost.CostValueXIndex)) return;

    costX = (long)upgradeCost.CostValuesX[upgradeCost.CostValueXIndex];
    if (soMoneyData.moneyData.booCoin >= costX)
    {
        if (upgradeTable.valueXIndex < upgradeTable.valuesX.Count - 1)
        {
            soMoneyData.moneyData.booCoin -= costX;
            float upgradeValue = upgradeTable.valuesX[++upgradeTable.valueXIndex];
            CoreGameSignals.Instance.onDataValueX?.Invoke(upgradeValue);
            upgradeCost.CostValueXIndex++;
            CoreUISignals.Instance.onUpgradeCostText?.Invoke(0, (long)upgradeCost.CostValuesX[upgradeCost.CostValueXIndex]);
        }
        else
        {
            Debug.Log("ValueX is at maximum level!");
            CoreUISignals.Instance.onButtonTexts?.Invoke(0);
        }
    }
    else
    {
        Debug.Log("Not enough BooCoins!");
    }
}
    public void UpgradeValueY()
    {
        if (!upgradeCost.CostValuesY.ContainsKey(upgradeCost.CostValueYIndex)) return;
          costY = (long)upgradeCost.CostValuesY[upgradeCost.CostValueYIndex];

        if (soMoneyData.moneyData.booCoin >= costY)
        {
            if (upgradeTable.valueYIndex < upgradeTable.valuesY.Count - 1)
            {
                 soMoneyData.moneyData.booCoin -= costY;
            Debug.Log(soMoneyData.moneyData.booCoin + " paramiz");
                float upgradeValue = upgradeTable.valuesY[++upgradeTable.valueYIndex];
                CoreGameSignals.Instance.onDataValueY?.Invoke(upgradeValue);
                upgradeCost.CostValueYIndex++;
                CoreUISignals.Instance.onUpgradeCostText?.Invoke(1,(long)upgradeCost.CostValuesY[upgradeCost.CostValueYIndex]);
            }
            else
            {
                Debug.Log("ValueZ is at maximum level!");
                CoreUISignals.Instance.onButtonTexts?.Invoke(1);
                // sinyal
                
                
            }
        }
        else
        {
            Debug.Log("Not enough BooCoins!");
            // sinyal
        }
    }

    public void UpgradeValueZ()
    {
       if (!upgradeCost.CostValuesZ.ContainsKey(upgradeCost.CostValueZIndex)) return;
          costZ = (long)upgradeCost.CostValuesZ[upgradeCost.CostValueZIndex];

               // CoreUISignals.Instance.onUpgradeCostText?.Invoke(2,costZ);
        if (soMoneyData.moneyData.booCoin >= costZ)
        {
            if (upgradeTable.valueZIndex < upgradeTable.valuesZ.Count - 1)
            {
                 soMoneyData.moneyData.booCoin -= costZ;
            Debug.Log(soMoneyData.moneyData.booCoin + " paramiz");
                float upgradeValue = upgradeTable.valuesZ[++upgradeTable.valueZIndex];
                CoreGameSignals.Instance.onDataValueZ?.Invoke(upgradeValue);
                upgradeCost.CostValueZIndex++;
                CoreUISignals.Instance.onUpgradeCostText?.Invoke(2,(long)upgradeCost.CostValuesZ[upgradeCost.CostValueZIndex]);
            }
            else
            {
                Debug.Log("ValueZ is at maximum level!");
                CoreUISignals.Instance.onButtonTexts?.Invoke(2);
                // sinyal
                
                
            }
        }
        else
        {
            Debug.Log("Not enough BooCoins!");
            // sinyal
        }
    }

    public void UpgradeValueA()
    {
       if (!upgradeCost.CostValuesA.ContainsKey(upgradeCost.CostValueAIndex)) return;
          costA = (long)upgradeCost.CostValuesA[upgradeCost.CostValueAIndex];

        if (soMoneyData.moneyData.booCoin >= costA)
        {
            if (upgradeTable.valueAIndex < upgradeTable.valuesA.Count - 1)
            {
                 soMoneyData.moneyData.booCoin -= costA;
            Debug.Log(soMoneyData.moneyData.booCoin + " paramiz");
                float upgradeValue = upgradeTable.valuesA[++upgradeTable.valueAIndex];
                CoreGameSignals.Instance.onDataValueA?.Invoke(upgradeValue);
                upgradeCost.CostValueAIndex++;
                CoreUISignals.Instance.onUpgradeCostText?.Invoke(3,(long)upgradeCost.CostValuesA[upgradeCost.CostValueAIndex]);
            }
            else
            {
                Debug.Log("ValueA is at maximum level!");
                CoreUISignals.Instance.onButtonTexts?.Invoke(3);
                // sinyal
                
                
            }
        }
        else
        {
            Debug.Log("Not enough BooCoins!");
            // sinyal
        }
    }

    public void UpgradeValueB()
    {
        if (!upgradeCost.CostValuesB.ContainsKey(upgradeCost.CostValueBIndex)) return;
          costB = (long)upgradeCost.CostValuesB[upgradeCost.CostValueBIndex];

        if (soMoneyData.moneyData.booCoin >= costB)
        {
            Debug.Log(soMoneyData.moneyData.booCoin + " paramiz");
            if (upgradeTable.valueBIndex < upgradeTable.valuesB.Count - 1)
            {
                 soMoneyData.moneyData.booCoin -= costB;
                float upgradeValue = upgradeTable.valuesB[++upgradeTable.valueBIndex];
                CoreGameSignals.Instance.onDataValueB?.Invoke(upgradeValue);
                upgradeCost.CostValueBIndex++;
               CoreUISignals.Instance.onUpgradeCostText?.Invoke(4,(long)upgradeCost.CostValuesB[upgradeCost.CostValueBIndex]);
            }
            else
            {
                Debug.Log("ValueB is at maximum level!");
                CoreUISignals.Instance.onButtonTexts?.Invoke(4);
                // sinyal
                
                
            }
        }
        else
        {
            Debug.Log("Not enough BooCoins!");
            // sinyal
        }
    }
}
