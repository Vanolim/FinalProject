using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] private BallGenerator _ballGenerator;
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private int _scoreForMaximumDifficulty;

    private void OnEnable()
    {
        _scoreHandler.OnChangedScore += SetTheDifficulty;
    }

    private void OnDisable()
    {
        _scoreHandler.OnChangedScore -= SetTheDifficulty;
    }

    private void SetTheDifficulty(int currentScore)
    {
        _ballGenerator.ChangeTimeBetweenSpawn(GetCurrentPercentageDifficulty(currentScore));
    }

    private float GetCurrentPercentageDifficulty(int currentScore)
    {
        return Mathf.InverseLerp(0, _scoreForMaximumDifficulty, currentScore);
    }
}
