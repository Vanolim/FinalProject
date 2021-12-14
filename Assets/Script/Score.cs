using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    private TMP_Text _scoreDisplay;
    private int _score;
    private int _initialScore = 1000;

    public event UnityAction NoScore;
    public event UnityAction<int> AddedScore;
    public event UnityAction Reset;
    public int ValueScore => _score;

    private void Start()
    {
        _scoreDisplay = GetComponent<TMP_Text>();
        _score = _initialScore;
        UpdateText();
    }

    public void Increase(int value)
    {
        _score += value;
        UpdateText();
        AddedScore?.Invoke(_score);
    }

    public void Decrease(int value)
    {
        _score -= value;
        UpdateText();
        if (_score <= 0)
        {
            NoScore?.Invoke();
        }
    }

    public void ResetScore()
    {
        _score = _initialScore;
        UpdateText();
        Reset?.Invoke();
    }

    private void UpdateText()
    {
        _scoreDisplay.text = "score: " + _score;
    }
}
