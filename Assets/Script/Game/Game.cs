using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private MenuButtonHandler _menuButtonHandler;
    [SerializeField] private GameState _gameState;
    [SerializeField] private TimeState _timeState;

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
        _timeState.Resume();
    }

    private void Pause()
    {
        _gameState.Pause();
        _timeState.Stop();
    }

    private void QuitTheGame()
    {
        _gameState.PrepareForClosing();
        Application.Quit();
    }

    private void Resume()
    {
        _gameState.Resume();
        _timeState.Resume();
    }

    private void ToLose()
    {
        _gameState.GameOver();
        _timeState.Stop();
    }
    
    private void LossCheck(int currentScore)
    {
        if (currentScore <= 0)
            ToLose();
    }
}
