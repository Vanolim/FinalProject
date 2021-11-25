using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class DeadBallZone : MonoBehaviour
{
    [SerializeField] private CatchingTheBall _ballCatchHandling;
    [SerializeField] private Score _score;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball ball))
        {
            _score.RemoveScore(ball.Price);
            _ballCatchHandling.UnsubscribeToTheBallButtonEvent(ball);
            ball.gameObject.SetActive(false);
            _audioSource.Play();
        }
    }
}
