using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;

    private TMP_Text _score;

    private void OnEnable()
    {
        _scoreHandler.OnChangedScore += UpdateText;
    }

    private void OnDisable()
    {
        _scoreHandler.OnChangedScore -= UpdateText;
    }

    private void Awake()
    {
        _score = GetComponent<TMP_Text>();
    }

    private void UpdateText(int valueScore)
    {
        _score.text = "score: " + valueScore;
    }
}
