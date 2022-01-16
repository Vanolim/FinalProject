using TMPro;
using UnityEngine;

public class MainPanel : Panel
{
    [SerializeField] private TMP_Text _bestResult;

    public void ShowTheBestResult(int value)
    {
        _bestResult.text = "Best result: " + value;
    }
}