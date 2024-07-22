using UnityEngine;

public class UIManager:MonoBehaviour
{
    /*
    void OnEnable()
    {
        
    }
    void OnDisable()
    {
        
    }
*/

    public void GamePausePanel()
    {
        CoreUISignals.Instance.onOpenPausePanel?.Invoke();
    }
    public void GameResumePanel()
    {
        CoreUISignals.Instance.onClosePausePanel?.Invoke();
    }








}
