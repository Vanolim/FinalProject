using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private MainPanel _mainPanel;
    [SerializeField] private BlockingPanel _blockingPanel;

    public void TurnOnGameOverPanel(int bestResult)
    {
        TurnOnRequiredPanels();
        _mainPanel.ShowTheBestResult(bestResult);
        _gameOverPanel.TurnOn();
    }

    public void TurnOnPausePanel(int bestResult)
    {
        TurnOnRequiredPanels();
        _mainPanel.ShowTheBestResult(bestResult);
        _pausePanel.TurnOn();
    }

    private void TurnOnRequiredPanels()
    {
        _blockingPanel.TurnOn();
        _mainPanel.TurnOn();
    }

    public void TurnOffPanels()
    {
        _mainPanel.TurnOff();
        _pausePanel.TurnOff();
        _gameOverPanel.TurnOff();
        _blockingPanel.TurnOff();
    }
}
