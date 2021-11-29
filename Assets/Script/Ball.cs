using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _minSpeedMovement;
    [SerializeField] private float _maxSpeedMovement;
    [SerializeField] private int _minPrice;
    [SerializeField] private int _maxPrice;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private Canvas _canvans;
    [SerializeField] private SpriteRenderer _paddinPositive;

    private SpriteRenderer _spriteRenderer;
    private int _price;
    private float _speedMovement;
    private bool _isPositiveBall;

    public event UnityAction<Ball, int> Caught;
    public int Price => _price;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _canvans.worldCamera = Camera.main;
    }

    private void OnEnable()
    {
        SetColor();
        SetUpPositivity();
        SetPrice();
        SetSpeedRelativeToPrice();
    }

    private void Update()
    {
        MoveDown();
    }

    public void ClickHandling()
    {
        Caught?.Invoke(this, _price);
        gameObject.SetActive(false);
    }

    private void SetUpPositivity()
    {
        float chanceBallPositive = 0.7f;

        if (Random.Range(0, 1f) <= chanceBallPositive)
        {
            _isPositiveBall = true;
            _paddinPositive.color = Color.white;
        }
        else
        {
            _isPositiveBall = false;
            _paddinPositive.color = Color.black;
        }
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
        _textScore.text = _price.ToString();
    }

    private void SetColor()
    {
        int fullyOpaqueColorValue = 1;

        Color newColor = new Color(SetValueForChannel(),
           SetValueForChannel(), SetValueForChannel(), fullyOpaqueColorValue);
        _spriteRenderer.color = newColor;
    }

    private float SetValueForChannel()
    {
        float maximumValueOfTheColorRange = 1;
        return Random.Range(0, maximumValueOfTheColorRange);
    }

    private void SetSpeedRelativeToPrice()
    {
        float interpolationValue = Mathf.InverseLerp(_minPrice, _maxPrice, _price);
        _speedMovement = Mathf.Lerp(_minSpeedMovement, _maxSpeedMovement, interpolationValue);
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * _speedMovement * Time.deltaTime);
    }
}
