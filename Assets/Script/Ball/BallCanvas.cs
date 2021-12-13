using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class BallCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayPrice;

    private Canvas _canvans;

    public void ResetPriceText(int price)
    {
        _displayPrice.text = price.ToString();
    }

    private void Start()
    {
        _canvans = GetComponent<Canvas>();
        _canvans.worldCamera = Camera.main;
    }
}
