using UnityEngine;

public class UIManager : MonoBehaviour
{

    public void OpenPausePanel()
    {
        CoreUISignals.Instance.onOpenPanels?.Invoke(0);
    }
    public void ClosePausePanel()
    {
        CoreUISignals.Instance.onClosePanels?.Invoke(0);
    }

    public void OpenUpgradeLoungePanel()
    {
        CoreUISignals.Instance.onOpenPanels?.Invoke(1);
    }
    public void OpenUpgradeKitchenPanel()
    {
        CoreUISignals.Instance.onOpenPanels?.Invoke(2);
    }
    public void OpenUpgradeWashingPanel()
    {
        CoreUISignals.Instance.onOpenPanels?.Invoke(3);
    }
    public void CloseUpgradeLoungePanel()
    {
        CoreUISignals.Instance.onClosePanels?.Invoke(1);
    }
    public void CloseUpgradeKitchenPanel()
    {
        CoreUISignals.Instance.onClosePanels?.Invoke(2);
    }
    public void CloseUpgradeWashingPanel()
    {
        CoreUISignals.Instance.onClosePanels?.Invoke(3);
    }






}
