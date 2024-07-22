using UnityEngine;
using UnityEngine.UI;
public enum UIEventSubscriptionTypes
{
    Pause,Resume
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
                button.onClick.AddListener(_manager.GamePausePanel);
                break;
                case UIEventSubscriptionTypes.Resume:
                button.onClick.AddListener(_manager.GameResumePanel);
                break;


        }
    }

    void UnsubscribeEvents()
    {
        switch (type)
        {
            case UIEventSubscriptionTypes.Pause:
                button.onClick.RemoveListener(_manager.GamePausePanel);
                break;
            case UIEventSubscriptionTypes.Resume:
                button.onClick.RemoveListener(_manager.GameResumePanel);
                break;
           

        }
    }

}