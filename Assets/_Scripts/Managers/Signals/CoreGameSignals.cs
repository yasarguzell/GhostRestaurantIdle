using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
   
    #region  Data Signals
    public UnityAction<float> onDataValueX=delegate{};
    public UnityAction<float> onDataValueY=delegate{};
    public UnityAction<float> onDataValueZ=delegate{};
    public UnityAction<float> onDataValueA=delegate{};
    public UnityAction<float> onDataValueB=delegate{};

    #endregion
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
