using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject loungePanel;
    [SerializeField] GameObject kitchenPanel;
    [SerializeField] GameObject washingPanel;



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
        CoreUISignals.Instance.onOpenLoungePanel += OnOpenLoungePanel;
        CoreUISignals.Instance.onCloseLoungePanel += OnCloseLoungePanel;
        CoreUISignals.Instance.onOpenKitchenPanel += OnOpenKitchenPanel;
        CoreUISignals.Instance.onCloseKitchenPanel += OnCloseKitchenPanel;
        CoreUISignals.Instance.onOpenWashingPanel += OnOpenWashingPanel;
        CoreUISignals.Instance.onCloseWashingPanel += OnCloseWashingPanel;
        CoreUISignals.Instance.onRoomUIIndex += OnRoomUIIndex;
    }

    private void OnRoomUIIndex(int arg0)
    {
        switch (arg0)
        {
            case 0:
                OnCloseKitchenPanel();
                OnCloseWashingPanel();
                OnOpenLoungePanel();
                break;
            case 1:
                OnCloseLoungePanel();
                OnCloseWashingPanel();
                OnOpenKitchenPanel();
                break;
            case 2:
                OnCloseKitchenPanel();
                OnCloseLoungePanel();
                OnOpenWashingPanel();
                break;
        }
    }

    private void OnCloseWashingPanel()
    {
        washingPanel.SetActive(false);
    }

    private void OnOpenWashingPanel()
    {
        washingPanel.SetActive(true);
    }

    private void OnCloseKitchenPanel()
    {
        kitchenPanel.SetActive(false);
    }

    private void OnOpenKitchenPanel()
    {
        kitchenPanel.SetActive(true);
    }

    private void OnCloseLoungePanel()
    {
        loungePanel.SetActive(false);
    }

    private void OnOpenLoungePanel()
    {
        loungePanel.SetActive(true);
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
