using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BallColor))]
[RequireComponent(typeof(BallMovement))]
public class Ball : PoolableObject
{
    [SerializeField] private int _minPrice;
    [SerializeField] private int _maxPrice;
    [SerializeField] private BallCanvas _ballCanvas;
    [SerializeField] private Button _caughtButton;

    private BallColor _color;
    private BallMovement _movement;

    private int _price;
    private bool _isPositive;

    public event UnityAction<Ball> OnCaught;
    public int Price => _price;

    private void OnEnable()
    {
        _caughtButton.onClick.AddListener(GetCaught);
    }

    private void OnDisable()
    {
        _caughtButton.onClick.RemoveListener(GetCaught);
    }

    private void Awake()
    {
        _color = GetComponent<BallColor>();
        _movement = GetComponent<BallMovement>();
    }

    private void GetCaught()
    {
        OnCaught?.Invoke(this);
        Deactivate();
    }

    public void Init()
    {
        _isPositive = GetUpPositivity();
        EstablishPrice();
        _movement.SetSpeed(GetInterpolatedPriceValue());
        _color.ResetColor();
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

    public Color GetColor()
    {
        return _color.ValueColor;
    }
}
