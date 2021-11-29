using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BestResultDispalay : MonoBehaviour
{
    [SerializeField] private Animator _rotateStar;
    [SerializeField] private TMP_Text _bestScore;
    [SerializeField] private Transform _startSprite;

    public void SetTheCurrentBestScore(int value)
    {
        UpdateText(value);
    }

    public void SetTheNewBestScore(int newBestResult)
    {
        UpdateText(newBestResult);

        if (_rotateStar.enabled == false)
            _rotateStar.enabled = true;
    }

    public void StopAnimation()
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
