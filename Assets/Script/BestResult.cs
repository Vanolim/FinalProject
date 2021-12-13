using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BestResultDispalay))]
public class BestResult : MonoBehaviour
{
    [SerializeField] private Score _score;

    private string _keyBestResult = "bestResult";
    private int _bestScore;
    private bool _bestScoreUpdate = false;

    public int BestScore => _bestScore;
    public event UnityAction<int> NewBestResultAchieved;

    private void OnEnable()
    {
        _score.AddedScore += CheckTheImprovementOfTheBestScore;
    }

    private void OnDisable()
    {
        _score.AddedScore -= CheckTheImprovementOfTheBestScore;
    }

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(_keyBestResult);
    }

    public void SaveTheBestResult()
    {
        if (_bestScoreUpdate)
            Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(_keyBestResult, _bestScore);
    }

    private void CheckTheImprovementOfTheBestScore(int currentScore)
    {
        if(currentScore > _bestScore)
        {
            _bestScoreUpdate = true;
            _bestScore = currentScore;
            NewBestResultAchieved?.Invoke(_bestScore);
        }
    }
}
