using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private StopPanel _stopPanel;
    [SerializeField] private BallGenerator _ballGenerator;
    [SerializeField] private Background _enviroment;
    [SerializeField] private BestResult _bestResult;
    [SerializeField] private int _scoreForMaximumDifficulty;

    private IEnumerator SetTheDifficultyJob;

    private void OnEnable()
    {
        _score.NoScore += ToLose;
    }

    private void OnDisable()
    {
        _score.NoScore -= ToLose;
    }

    private void Start()
    {
        _enviroment.UpdateEnvironment();
        SetTheDifficultyJob = SetTheDifficulty();
        StartCoroutine(SetTheDifficultyJob);
    }

    public void Restart()
    {
        _ballGenerator.ResetActiveBalls();
        _stopPanel.HidePanels();
        _score.ResetScore();
        _enviroment.UpdateEnvironment();
        _bestResult.SaveTheBestResult();
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _stopPanel.ShowPausePanel();
        _stopPanel.ShowTheBestResult(_bestResult.BestScore);
    }

    public void QuitTheGame()
    {
        _bestResult.SaveTheBestResult();
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _bestResult.SaveTheBestResult();
        _stopPanel.HidePanels();
    }

    private void ToLose()
    {
        Time.timeScale = 0;
        _stopPanel.ShowGameOverPanel();
        _stopPanel.ShowTheBestResult(_bestResult.BestScore);
    }

    private float GetCurrentPercentageDifficulty()
    {
        return Mathf.InverseLerp(0, _scoreForMaximumDifficulty, _score.ValueScore);
    }

    private IEnumerator SetTheDifficulty()
    {
        var timeBetweenChange = new WaitForSeconds(0.1f);

        while (true)
        {
            _ballGenerator.ChangeTimeBetweenSpawn(GetCurrentPercentageDifficulty());
            yield return timeBetweenChange;
        }
    }
}
