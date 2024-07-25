using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{
    public static MoneyManagement Instance { get; set; }
    public TMP_Text booCoinCountText;

    private SOMoneyData moneyDataObj;

    private void Awake()
    {
        Instance = this;
        moneyDataObj = Resources.Load<SOMoneyData>("Datas/MoneyData");
        booCoinCountText.text = FormatMoney(moneyDataObj.moneyData.booCoin);
    }
    void Update()
    {
        booCoinCountText.text = FormatMoney(moneyDataObj.moneyData.booCoin);
       
    }

    public void UpdateBooCoin(int amount)
    {
        moneyDataObj.moneyData.booCoin += amount;
        booCoinCountText.text = FormatMoney(moneyDataObj.moneyData.booCoin);
    }

    public static string FormatMoney(long amount)
    {
        if (amount >= 1000000000)
        {
            return (amount / 1000000000D).ToString("0.#") + "b";
        }
        else if (amount >= 1000000)
        {
            return (amount / 1000000D).ToString("0.#") + "m";
        }
        else if (amount >= 1000)
        {
            return (amount / 1000D).ToString("0.#") + "k";
        }
        else
        {
            return amount.ToString("#,0");
        }
    }
}
