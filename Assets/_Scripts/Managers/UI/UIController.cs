using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIController : MonoBehaviour
{

    [SerializeField] private List<GameObject> upgradePanels = new List<GameObject>();
    [SerializeField] private List<GameObject> upgradeButtons = new List<GameObject>();
    [SerializeField] private List<TMP_Text> buttonTexts = new List<TMP_Text>(); // 0=X 1=Y 2=Z 3=A 4=B
    [SerializeField] private List<TMP_Text> costTexts = new List<TMP_Text>();


    void Start()
    {
        CoreUISignals.Instance.onOpenPanels += onOpenPanel;
        CoreUISignals.Instance.onClosePanels += onClosePanel;
        CoreUISignals.Instance.onRoomUIIndex += onRoomUIIndex;
        CoreUISignals.Instance.onButtonTexts += onButtonTexts;
        CoreUISignals.Instance.onUpgradeCostText += onUpgradeCostText;
    }

    private void onUpgradeCostText(byte arg0, long arg1)
    {
         costTexts[(int)arg0].text = arg1.ToString();
    }


    private void onButtonTexts(int arg0)
    {
        buttonTexts[arg0].text = "MAX UPGRADE";
    }

    private void onRoomUIIndex(int arg0)
    {
        switch (arg0)
        {
            case 0:

                upgradeButtons[0].SetActive(true); // 0=lounge 1=kitchen 2=washing
                upgradeButtons[1].SetActive(false);
                upgradeButtons[2].SetActive(false);

                break;
            case 1:

                upgradeButtons[0].SetActive(false);
                upgradeButtons[1].SetActive(true);
                upgradeButtons[2].SetActive(false);

                break;
            case 2:

                upgradeButtons[0].SetActive(false);
                upgradeButtons[1].SetActive(false);
                upgradeButtons[2].SetActive(true);
                break;
        }
    }

    private void onClosePanel(int arg0)
    {
        upgradePanels[arg0].SetActive(false);
        CoreUISignals.Instance.isPanelOpen(false);
    }

    private void onOpenPanel(int arg0)
    {
        upgradePanels[arg0].SetActive(true);
        CoreUISignals.Instance.isPanelOpen(true);
    }
}
