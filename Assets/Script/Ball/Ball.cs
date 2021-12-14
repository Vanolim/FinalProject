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

    private BallColor _color;
    private BallMovement _movement;

    private int _price;
    private bool _isPositive;

    public event UnityAction<Ball> Caught;
    public int Price => _price;

    private void Awake()
    {
        _color = GetComponent<BallColor>();
        _movement = GetComponent<BallMovement>();
    }

    public void Init()
    {
        _isPositive = GetUpPositivity();
        EstablishPrice();
        _movement.SetSpeed(GetInterpolatedPriceValue());
        _color.ResetColor();
    }

    public void ClickHandling()
    {
        if (Time.timeScale == 1)
        {
            Caught?.Invoke(this);
            gameObject.SetActive(false);
        }
    }

    private bool GetUpPositivity()
    {
        int chanceBallPositive = 70;
        return Random.Range(0, 100) <= chanceBallPositive;
    }

    private void EstablishPrice()
    {
        _price = Random.Range(_minPrice, _maxPrice);
        if (_isPositive == false)
            _price *= -1;

        _ballCanvas.ResetPriceText(_price);
    }

    private float GetInterpolatedPriceValue() => Mathf.InverseLerp(_minPrice, _maxPrice, Mathf.Abs(_price));
}
