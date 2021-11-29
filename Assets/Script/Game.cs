using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private StopPanel _stopPanel;
    [SerializeField] private BallGenerator _ballGenerator;
    [SerializeField] private ChangeBackgroundWithMusic _enviroment;
    [SerializeField] private int __scoreForMaximumDifficulty;

    private IEnumerator SetTheDifficultyByTheCurrentValueOfScoreJob;

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
        SetTheDifficultyByTheCurrentValueOfScoreJob = SetTheDifficultyByTheCurrentOfScore();
        StartCoroutine(SetTheDifficultyByTheCurrentValueOfScoreJob);
    }

    private void Update()
    {
        SetComplexity();
    }

    public void Restart()
    {
        _ballGenerator.Reset();
        _stopPanel.HidePanels();
        _score.ResetScore();
        _enviroment.UpdateEnvironment();
        StopCoroutine(SetTheDifficultyByTheCurrentValueOfScoreJob);
        StartCoroutine(SetTheDifficultyByTheCurrentValueOfScoreJob);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _stopPanel.ShowPausePanel();
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _stopPanel.HidePanels();
    }

    private void ToLose()
    {
        Time.timeScale = 0;
        _stopPanel.ShowGameOverPanel();
    }

    private void SetComplexity()
    {
        float difficultyValueInPercentage = Mathf.InverseLerp(0, __scoreForMaximumDifficulty, _score.ValueScore);
        _ballGenerator.SetTimeBetweenSpawn(difficultyValueInPercentage);
    }

    private IEnumerator SetTheDifficultyByTheCurrentOfScore()
    {
        var timeBetweenChange = new WaitForSeconds(0.5f);

        while (true)
        {
            SetComplexity();
            yield return timeBetweenChange;
        }
    }
}
