using System;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private BallGenerator _ballGenerator;
    [SerializeField] private DeadZone _deadZone;

    public event Action<Ball> OnBallCaught;
    public event Action OnSuccess;
    public event Action OnFailed;

    private void OnEnable()
    {
        _ballGenerator.OnBallSpawned += SubscribeToCatchTheBall;
        _ballGenerator.OnBallReset += UnsubscribeToCatchTheBall;
        _deadZone.OnBallInDeadZone += RemoveScoreForFailedBall;
    }

    private void OnDisable()
    {
        _ballGenerator.OnBallSpawned -= SubscribeToCatchTheBall;
        _ballGenerator.OnBallReset -= UnsubscribeToCatchTheBall;
        _deadZone.OnBallInDeadZone -= RemoveScoreForFailedBall;
    }

    private void SubscribeToCatchTheBall(Ball ball)
    {
        ball.OnCaught += BallCaught;
    }

    private void UnsubscribeToCatchTheBall(Ball ball)
    {
        ball.OnCaught -= BallCaught;
    }

    private void BallCaught(Ball ball)
    {
        OnBallCaught?.Invoke(ball);
        AddScoreForTheBallOnCaught(ball);
    }

    private void AddScoreForTheBallOnCaught(Ball caughtBall)
    {
        int ballScore = caughtBall.Price;
        if (caughtBall.Price < 0)
        {
            _scoreHandler.Decrease(ballScore * -1);
            OnFailed?.Invoke();
        }
        else
        {
            _scoreHandler.Increase(ballScore);
            OnSuccess?.Invoke();
        }

        UnsubscribeToCatchTheBall(caughtBall);
    }

    private void RemoveScoreForFailedBall(Ball failedBall)
    {
        int ballScore = failedBall.Price;
        if (ballScore > 0)
        {
            _scoreHandler.Decrease(ballScore);
            OnFailed?.Invoke();
        }

        UnsubscribeToCatchTheBall(failedBall);
        failedBall.Deactivate();
    }
}
