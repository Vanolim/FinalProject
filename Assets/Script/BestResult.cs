using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BestResultDispalay))]
public class BestResult : MonoBehaviour
{
    [SerializeField] private Score _score;

    private BestResultDispalay _bestResultDisplay;
    private string _keyBestResult = "bestResult";
    private int _bestScore;
    private bool _bestScoreUpdate = false;

    public int BestScore => _bestScore;

    private void OnEnable()
    {
        _score.AddedScore += CheckTheImprovementOfTheBestScore;
        _score.Reset += ResetBestResultDisplay;
    }

    private void OnDisable()
    {
        _score.AddedScore -= CheckTheImprovementOfTheBestScore;
        _score.Reset -= ResetBestResultDisplay;
    }

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(_keyBestResult);
        _bestResultDisplay = GetComponent<BestResultDispalay>();
        _bestResultDisplay.SetTheCurrentBestScore(_bestScore);
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
            _bestResultDisplay.SetTheNewBestScore(_bestScore);
        }
    }

    private void ResetBestResultDisplay()
    {
        _bestResultDisplay.StopAnimation();
    }
}
