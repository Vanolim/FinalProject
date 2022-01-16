using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _padding;
    [SerializeField] private TMP_Text _displayPrice;

    private SpriteRenderer _spriteRenderer;

    public Color ValueColor => _spriteRenderer.color;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ResetColor()
    {
        Color newColor = new Color(GetRandomValueForChannel(), GetRandomValueForChannel(), GetRandomValueForChannel());
        _spriteRenderer.color = newColor;
        _padding.color = DefineOppositeColorForPadding(newColor);
        _displayPrice.color = _padding.color;
    }

    private float GetRandomValueForChannel() => Random.Range(0f, 1f);

    private Color DefineOppositeColorForPadding(Color colorBall)
    {
        float additionalValue = 0.5f;
        float maxValue = 1f;
        float[] colorValues = new float[3] { colorBall.r, colorBall.g, colorBall.b };

        for (int i = 0; i < colorValues.Length; i++)
        {
            if (colorValues[i] + additionalValue >= 1f)
                colorValues[i] = 0 + (maxValue - colorValues[i]);
            else
                colorValues[i] += additionalValue;
        }

        return new Color(colorValues[0], colorValues[1], colorValues[2]);
    }
}
