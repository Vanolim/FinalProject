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

    private SpriteRenderer _spriteRenderer;
    private int _price;
    private float _speedMovement;

    public event UnityAction<Ball, int> BallCaught;
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
        SetPrice();
        SetTheSpeedValueDependingOnTheNumberOfPrice();
    }

    private void Update()
    {
        DownwardMovement();
    }

    public void ClickHandling()
    {
        BallCaught?.Invoke(this, _price);
        gameObject.SetActive(false);
    }

    private void SetPrice()
    {
        _price = Random.Range(_minPrice, _maxPrice);
        SetGlassesText();
    }

    private void SetGlassesText()
    {
        _textScore.text = _price.ToString();
    }

    private void SetColor()
    {
        int fullyOpaqueColorValue = 1;

        Color newColor = new Color(GetRandomValueForColorChannel(),
           GetRandomValueForColorChannel(), GetRandomValueForColorChannel(), fullyOpaqueColorValue);
        _spriteRenderer.color = newColor;
    }

    private float GetRandomValueForColorChannel()
    {
        float maximumValueOfTheColorRange = 1;
        return Random.Range(0, maximumValueOfTheColorRange);
    }

    private void SetTheSpeedValueDependingOnTheNumberOfPrice()
    {
        float interpolationValue = Mathf.InverseLerp(_minPrice, _maxPrice, _price);
        _speedMovement = Mathf.Lerp(_minSpeedMovement, _maxSpeedMovement, interpolationValue);
    }

    private void DownwardMovement()
    {
        transform.Translate(Vector2.down * _speedMovement * Time.deltaTime);
    }
}
