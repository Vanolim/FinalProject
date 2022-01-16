using TMPro;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(TMP_Text))]
public class BallCanvas : MonoBehaviour
{
    private TMP_Text _displayPrice;
    private Canvas _canvas;

    public void ResetPriceText(int price)
    {
        _displayPrice.text = price.ToString();
    }

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _displayPrice = GetComponent<TMP_Text>();
        _canvas.worldCamera = Camera.main;
    }
}
