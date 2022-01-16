using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BestResultView : MonoBehaviour
{
    [SerializeField] private BestResult _bestResult;
    [SerializeField] private StarUI _starUI;
    [SerializeField] private TMP_Text _bestScore;

    private void OnEnable()
    {
        _bestResult.OnNewBestResultAchieved += SetTheNewBestScore;
    }

    private void OnDisable()
    {
        _bestResult.OnNewBestResultAchieved -= SetTheNewBestScore;
    }

    private void Start()
    {
        UpdateText(_bestResult.BestScore);
    }

    private void SetTheNewBestScore(int newBestResult)
    {
        _starUI.ActivateAnimation();
        UpdateText(newBestResult);
    }

    private void UpdateText(int score)
    {
        _bestScore.text = score.ToString();
    }
}
