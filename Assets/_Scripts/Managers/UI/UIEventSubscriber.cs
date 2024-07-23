using UnityEngine;
using UnityEngine.UI;
public enum UIEventSubscriptionTypes
{
    Pause,Resume,UpgradeLounge,UpgradeKitchen,UpgradeWashing,CloseUpgradeLounge,CloseUpgradeKitchen,CloseUpgradeWashing
}
public class UIEventSubscriber : MonoBehaviour
{

    [SerializeField] private UIEventSubscriptionTypes type;
    [SerializeField] Button button;
    private UIManager _manager;

    void Awake()
    {
        GetReferences();
    }

    private void GetReferences()
    {
        _manager = FindObjectOfType<UIManager>();
    }

    void OnEnable()
    {
        SubscribeEvents();
    }

    void OnDisable()
    {
        UnsubscribeEvents();
    }

    void SubscribeEvents()
    {
        switch (type)
        {
          case UIEventSubscriptionTypes.Pause:
                button.onClick.AddListener(_manager.OpenPausePanel);
                break;
            case UIEventSubscriptionTypes.Resume:
                button.onClick.AddListener(_manager.ClosePausePanel);
                break;
            case UIEventSubscriptionTypes.UpgradeLounge:
                button.onClick.AddListener(_manager.OpenUpgradeLoungePanel);
                break;
            case UIEventSubscriptionTypes.UpgradeKitchen:   
                button.onClick.AddListener(_manager.OpenUpgradeKitchenPanel);
                break;
            case UIEventSubscriptionTypes.UpgradeWashing:   
                button.onClick.AddListener(_manager.OpenUpgradeWashingPanel);
                break;
            case UIEventSubscriptionTypes.CloseUpgradeWashing:
                button.onClick.AddListener(_manager.CloseUpgradeWashingPanel);
                break;
            case UIEventSubscriptionTypes.CloseUpgradeLounge:
                button.onClick.AddListener(_manager.CloseUpgradeLoungePanel);
                break;
            case UIEventSubscriptionTypes.CloseUpgradeKitchen:
                button.onClick.AddListener(_manager.CloseUpgradeKitchenPanel);
                break;

        }
    }

    void UnsubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.Pause:
                button.onClick.RemoveListener(_manager.OpenPausePanel);
                break;
            case UIEventSubscriptionTypes.Resume:
                button.onClick.RemoveListener(_manager.ClosePausePanel);
                break;
            case UIEventSubscriptionTypes.UpgradeLounge:
                button.onClick.RemoveListener(_manager.OpenUpgradeLoungePanel);
                break;
            case UIEventSubscriptionTypes.UpgradeKitchen:
                button.onClick.RemoveListener(_manager.OpenUpgradeKitchenPanel);
                break;
            case UIEventSubscriptionTypes.UpgradeWashing:
                button.onClick.RemoveListener(_manager.OpenUpgradeWashingPanel);
                break;
            case UIEventSubscriptionTypes.CloseUpgradeWashing:
                button.onClick.RemoveListener(_manager.CloseUpgradeWashingPanel);
                break;
            case UIEventSubscriptionTypes.CloseUpgradeLounge:
                button.onClick.RemoveListener(_manager.CloseUpgradeLoungePanel);
                break;
            case UIEventSubscriptionTypes.CloseUpgradeKitchen:
                button.onClick.RemoveListener(_manager.CloseUpgradeKitchenPanel);
                break;

           

        }
    }

}