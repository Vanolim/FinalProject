using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadBallZone : MonoBehaviour
{
    [SerializeField] private BallHandler _ballCatchHandling;
    [SerializeField] private Score _score;
    [SerializeField] private AudioSource _audioSourceNegative;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball ball))
        {
            if(ball.Price > 0)
            {
                _score.Decrease(ball.Price);
                _audioSourceNegative.Play();
            }
            _ballCatchHandling.UnsubscribeToCatchTheBall(ball);
            ball.gameObject.SetActive(false);
        }
    }
}
