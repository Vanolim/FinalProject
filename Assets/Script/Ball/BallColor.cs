using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _padding;

    private SpriteRenderer _spriteRenderer;

    public Color Padding => _padding.color;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor()
    {

        Color newColor = new Color(SetValueForChannel(),
           SetValueForChannel(), SetValueForChannel());
        _spriteRenderer.color = newColor;
        SetOppositeColorForPadding(newColor);
    }

    private float SetValueForChannel()
    {
        float maximumValueOfTheColorRange = 1;
        return Random.Range(0, maximumValueOfTheColorRange);
    }

    private void SetOppositeColorForPadding(Color colorBall)
    {
        float additionalValue = 0.5f;
        float maxValue = 1f;
        float[] colorValues = new float[3] { colorBall.r, colorBall.g, colorBall.b };

        for (int i = 0; i < colorValues.Length; i++)
        {
            if (CheckThatNewColorOutOfBounds(colorValues[i] + additionalValue))
                colorValues[i] = 0 + (maxValue - colorValues[i]);
            else
                colorValues[i] = colorValues[i] + additionalValue;
        }

        Color colorPadding = new Color(colorValues[0], colorValues[1], colorValues[2]);
        _padding.color = colorPadding;
    }

    private bool CheckThatNewColorOutOfBounds(float value)
    {
        float bound = 1f;

        if (value >= bound)
            return true;
        else 
            return false;
    }
}
