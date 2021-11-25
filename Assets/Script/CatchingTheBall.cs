using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class CatchingTheBall : MonoBehaviour
{
    [SerializeField] private Score _score;

    private AudioSource _volumeCapture;

    private void Awake()
    {
        _volumeCapture = GetComponent<AudioSource>();
    }

    public void SubscribeToTheBallCaughtEvent(Ball ball)
    {
        ball.BallCaught += AddScoreForTheBallCaught;
    }

    public void UnsubscribeToTheBallButtonEvent(Ball ball)
    {
        ball.BallCaught -= AddScoreForTheBallCaught;
    }

    private void AddScoreForTheBallCaught(Ball caughtBall, int score)
    {
        _score.AddScore(score);
        PlayVolumeCaptureSound();
        UnsubscribeToTheBallButtonEvent(caughtBall);
    }

    private void PlayVolumeCaptureSound()
    {
        _volumeCapture.pitch = Random.Range(0.7f, 1.3f);
        _volumeCapture.Play();
    }
}
