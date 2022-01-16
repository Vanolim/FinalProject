using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public event Action<Ball> OnBallInDeadZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ball>(out Ball ball))
            OnBallInDeadZone?.Invoke(ball);
    }
}
