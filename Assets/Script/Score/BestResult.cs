using System;
using UnityEngine;

public class BestResult : MonoBehaviour
{
    [SerializeField] private ScoreHandler scoreHandler;
    
    private const string KeyBestResult = "bestResult";

    private int _bestScore;
    private bool _bestScoreUpdate = false;

    public int BestScore => _bestScore;
    public event Action<int> OnNewBestResultAchieved;

    private void OnEnable()
    {
        scoreHandler.OnChangedScore += CheckTheImprovementOfTheBestScoreHandler;
    }

    private void OnDisable()
    {
        scoreHandler.OnChangedScore -= CheckTheImprovementOfTheBestScoreHandler;
    }

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(KeyBestResult);
    }

    private void CheckTheImprovementOfTheBestScoreHandler(int currentScore)
    {
        if(currentScore > _bestScore)
        {
            _bestScoreUpdate = true;
            _bestScore = currentScore;
            OnNewBestResultAchieved?.Invoke(_bestScore);
        }
    }

    public void TrySaveTheBestResult()
    {
        if (_bestScoreUpdate)
            Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(KeyBestResult, _bestScore);
    }
}
