using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class BallCanvas : MonoBehaviour
{
    private Canvas _canvans;

    private void Start()
    {
        _canvans = GetComponent<Canvas>();
        _canvans.worldCamera = Camera.main;
    }
}
