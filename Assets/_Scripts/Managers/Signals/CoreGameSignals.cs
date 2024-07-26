using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
   
    #region  Data Signals
    public UnityAction<float> onDataUpgradeChefCookSpeed=delegate{};
    public UnityAction<float> onDataUpgradeChefMovementSpeed=delegate{};
    public UnityAction<float> onDataUpgradeWaitersSpeed=delegate{};
    public UnityAction<float> onDataUpgradeWashingWorkerSpeed=delegate{};
    public UnityAction<float> onDataUpgradeWashSpeed=delegate{};
    public UnityAction onDataChanged;

    #endregion

    public UnityAction onNewRestaurant = delegate { };
    public static CoreGameSignals Instance { get; private set; }
   void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    else
    {
        Destroy(this.gameObject);
    }
}

}
