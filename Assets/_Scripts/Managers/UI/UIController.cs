using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
 
    public List<GameObject> upgradePanels=new List<GameObject>();
    public List<GameObject> upgradeButtons=new List<GameObject>();


    void Start()
    {
        CoreUISignals.Instance.onOpenPanels+=onOpenPanel;
        CoreUISignals.Instance.onClosePanels+=onClosePanel;
        CoreUISignals.Instance.onRoomUIIndex+=onRoomUIIndex;
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
    }

    private void onOpenPanel(int arg0)
    {
       upgradePanels[arg0].SetActive(true);
    }
}
