using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    public void ShowPausePanel()
    {
        _pausePanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void HidePanels()
    {
        _pausePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }
}
