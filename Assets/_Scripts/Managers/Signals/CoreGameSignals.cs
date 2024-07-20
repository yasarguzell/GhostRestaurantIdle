using UnityEngine;
using UnityEngine.Events;

public class CoreGameSignals : MonoBehaviour
{
    public UnityAction onGameStart = delegate { };
    public UnityAction onGamePause = delegate { };
    public UnityAction onGameResume = delegate { };
   

    #region  Data Signals
    public UnityAction<float> onDataValueX=delegate{};

    #endregion
    public static CoreGameSignals Instance { get; private set; }
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            DontDestroyOnLoad(this);
        }
    }

}
