using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopPanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _bestResultPausePanel;
    [SerializeField] private TMP_Text _bestResultGameOverPanel;
    public void ShowPausePanel()
    {
        _pausePanel.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void ShowTheBestResult(int value)
    {
        if (_pausePanel.activeSelf)
            _bestResultPausePanel.text = "Best result: " + value;
        else
            _bestResultGameOverPanel.text = "Best result: " + value;
    }

    public void HidePanels()
    {
        _pausePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
    }
}
