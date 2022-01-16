using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private BallGenerator _ballGenerator;
    [SerializeField] private BallExplosionParticleGenerator _ballExplosionParticleGenerator;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private Background _background;
    [SerializeField] private BestResult _bestResult;
    [SerializeField] private MenuHandler _menuHandler;

    public void Restart()
    {
        _ballGenerator.ResetActiveBalls();
        _ballExplosionParticleGenerator.ResetActiveParticle();
        _scoreHandler.Reset();
        _background.Reset();
        _bestResult.TrySaveTheBestResult();
        _menuHandler.TurnOffPanels();
    }

    public void Pause()
    {
        _menuHandler.TurnOnPausePanel(_bestResult.BestScore);
    }

    public void Resume()
    {
        _menuHandler.TurnOffPanels();
    }

    public void GameOver()
    {
        _menuHandler.TurnOnGameOverPanel(_bestResult.BestScore);
    }

    public void PrepareForClosing()
    {
        _bestResult.TrySaveTheBestResult();
    }
}
