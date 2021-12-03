using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _minSpeedMovement;
    [SerializeField] private float _maxSpeedMovement;

    private float _speedMovement;

    private void Update()
    {
        MoveDown();
    }

    public void SetSpeedMovement(float interpolationPriceValue)
    {
        _speedMovement = Mathf.Lerp(_minSpeedMovement, _maxSpeedMovement, interpolationPriceValue);
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * _speedMovement * Time.deltaTime);
    }
}
