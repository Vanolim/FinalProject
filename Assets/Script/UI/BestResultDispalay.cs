using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BestResultDispalay : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private BestResult _bestResult;

    [SerializeField] private Animator _rotateStar;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private Transform _startSprite;

    private void OnEnable()
    {
        _score.Reset += StopAnimation;
        _bestResult.NewBestResultAchieved += SetTheNewBestScore;
    }

    private void OnDisable()
    {
        _score.Reset -= StopAnimation;
        _bestResult.NewBestResultAchieved -= SetTheNewBestScore;
    }

    private void Start()
    {
        UpdateText(_bestResult.BestScore);
    }

    private void SetTheNewBestScore(int newBestResult)
    {
        UpdateText(newBestResult);

        if (_rotateStar.enabled == false)
            _rotateStar.enabled = true;
    }

    private void StopAnimation()
    {
        if (_rotateStar.enabled)
            _rotateStar.enabled = false;
        ResetRotationValues();
    }

    private void ResetRotationValues()
    {
        _startSprite.rotation = Quaternion.identity;
    }

    private void UpdateText(int score)
    {
        _bestScore.text = score.ToString();
    }
}
