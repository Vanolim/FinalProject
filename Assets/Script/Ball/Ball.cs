using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallColor))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _minSpeedMovement;
    [SerializeField] private float _maxSpeedMovement;
    [SerializeField] private int _minPrice;
    [SerializeField] private int _maxPrice;
    [SerializeField] private TMP_Text _displayPrice;

    private int _price;
    private float _speedMovement;
    private bool _isPositiveBall;
    private BallColor _ballColor;

    public event UnityAction<Ball> Caught;
    public int Price => _price;

    private void Awake()
    {
        _ballColor = GetComponent<BallColor>();
    }

    public void SetState()
    {
        SetUpPositivity();
        SetPrice();
        SetSpeedRelativeToPrice();
        _ballColor.SetColor();
        _displayPrice.color = _ballColor.Padding;
    }

    private void Update()
    {
        MoveDown();
    }

    public void ClickHandling()
    {
        Caught?.Invoke(this);
        gameObject.SetActive(false);
    }

    private void SetUpPositivity()
    {
        int chanceBallPositive = 70;

        if (Random.Range(0, 100) <= chanceBallPositive)
            _isPositiveBall = true;
        else
            _isPositiveBall = false;
    }

    private void SetPrice()
    {
        _price = Random.Range(_minPrice, _maxPrice);
        if (_isPositiveBall == false)
            _price *= -1;

        SetPriceText();
    }

    private void SetPriceText()
    {
        _displayPrice.text = _price.ToString();
    }

    private void SetSpeedRelativeToPrice()
    {
        int moduloPrice;
        if (_price < 0)
            moduloPrice = _price * -1;
        else
            moduloPrice = _price;

        float interpolationValue = Mathf.InverseLerp(_minPrice, _maxPrice, moduloPrice);
        _speedMovement = Mathf.Lerp(_minSpeedMovement, _maxSpeedMovement, interpolationValue);
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * _speedMovement * Time.deltaTime);
    }
}
