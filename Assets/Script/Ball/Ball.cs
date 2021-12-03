using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallColor))]
[RequireComponent(typeof(BallMovement))]
public class Ball : MonoBehaviour
{
    [SerializeField] private int _minPrice;
    [SerializeField] private int _maxPrice;
    [SerializeField] private BallCanvas _ballCanvas;

    private BallColor _ballColor;
    private BallMovement _ballMovement;

    private int _price;
    private bool _isPositiveBall;

    public event UnityAction<Ball> Caught;
    public int Price => _price;

    private void Awake()
    {
        _ballColor = GetComponent<BallColor>();
        _ballMovement = GetComponent<BallMovement>();
    }

    public void UpdateState()
    {
        _isPositiveBall = SetUpPositivity();
        SetPrice();
        _ballMovement.SetSpeedMovement(GetInterpolatedPriceValue());
        _ballColor.SetColor();
    }

    public void ClickHandling()
    {
        Caught?.Invoke(this);
        gameObject.SetActive(false);
    }

    private bool SetUpPositivity()
    {
        int chanceBallPositive = 70;
        return Random.Range(0, 100) <= chanceBallPositive;
    }

    private void SetPrice()
    {
        _price = Random.Range(_minPrice, _maxPrice);
        if (_isPositiveBall == false)
            _price *= -1;

        _ballCanvas.SetPriveText(_price);
    }

    private float GetInterpolatedPriceValue() => Mathf.InverseLerp(_minPrice, _maxPrice, Mathf.Abs(_price));
}
