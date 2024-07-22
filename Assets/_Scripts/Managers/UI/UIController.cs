using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
  [SerializeField] GameObject pausePanel;



  void OnEnable()
  {
    Subscribe();
  }
  void OnDisable()
  {
    UnSubscribe();
  }
 
  void Subscribe()
  {
    CoreUISignals.Instance.onOpenPausePanel += OnOpenPausePanel;
    CoreUISignals.Instance.onClosePausePanel += OnClosePausePanel;
  }

    private void OnClosePausePanel()
    {
        pausePanel.SetActive(false);
    }

    private void OnOpenPausePanel()
    {
       pausePanel.SetActive(true);
    }

    void UnSubscribe()
  {
    CoreUISignals.Instance.onOpenPausePanel -= OnOpenPausePanel;
    CoreUISignals.Instance.onClosePausePanel -= OnClosePausePanel;
  }
}
