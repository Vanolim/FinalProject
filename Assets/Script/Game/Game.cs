using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private MenuButtonHandler _menuButtonHandler;
    [SerializeField] private GameState _gameState;

    private void OnEnable()
    {
        _scoreHandler.OnChangedScore += LossCheck;
        _menuButtonHandler.OnRestart += Restart;
        _menuButtonHandler.OnExit += QuitTheGame;
        _menuButtonHandler.OnResume += Resume;
        _menuButtonHandler.OnPause += Pause;
    }

    private void OnDisable()
    {
        _scoreHandler.OnChangedScore -= LossCheck;
        _menuButtonHandler.OnRestart -= Restart;
        _menuButtonHandler.OnExit -= QuitTheGame;
        _menuButtonHandler.OnResume -= Resume;
        _menuButtonHandler.OnPause -= Pause;
    }

    private void Restart()
    {
        _gameState.Restart();
        Time.timeScale = 1;
    }

    private void Pause()
    {
        _gameState.Pause();
        Time.timeScale = 0;
    }

    private void QuitTheGame()
    {
        _gameState.PrepareForClosing();
        Application.Quit();
    }

    private void Resume()
    {
        _gameState.Resume();
        Time.timeScale = 1;
    }

    private void ToLose()
    {
        _gameState.GameOver();
        Time.timeScale = 0;
    }
    
    private void LossCheck(int currentScore)
    {
        if (currentScore <= 0)
            ToLose();
    }
}
