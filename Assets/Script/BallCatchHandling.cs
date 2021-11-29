using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCatchHandling : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private AudioSource _audioSourcePositive;
    [SerializeField] private AudioSource _audioSourceNegative;

    public void SubscribeToCatchTheBall(Ball ball)
    {
        ball.Caught += AddScoreForTheBallCaught;
    }

    public void UnsubscribeToCatchTheBall(Ball ball)
    {
        ball.Caught -= AddScoreForTheBallCaught;
    }

    private void AddScoreForTheBallCaught(Ball caughtBall)
    {
        int ballScore = caughtBall.Price;
        if (caughtBall.Price < 0)
        {
            _score.RemoveScore(ballScore * -1);
            PlayNegativeSound();
        }
        else
        {
            _score.AddScore(ballScore);
            PlayPositiveSound();
        }

        UnsubscribeToCatchTheBall(caughtBall);
    }

    private void PlayPositiveSound()
    {
        _audioSourcePositive.pitch = Random.Range(0.7f, 1.3f);
        _audioSourcePositive.Play();
    }

    private void PlayNegativeSound()
    {
        _audioSourceNegative.Play();
    }
}
