using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private int _initialScore;
    
    private int _score;
    
    public event Action<int> OnChangedScore;

    public int Score
    {
        private set
        {
            _score = value;
            OnChangedScore?.Invoke(_score);
        }
        get => _score;
    }

    private void Start()
    {
        Score = _initialScore;
    }

    public void Increase(int value)
    {
        Score += value;
    }

    public void Decrease(int value)
    {
        Score -= value;
    }

    public void Reset()
    {
        Score = _initialScore;
    }
}
