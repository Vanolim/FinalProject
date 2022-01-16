using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] private Ball _template;
    [Header("PositionSpawnBall")]
    [SerializeField] private Transform _startingPointOfSpawn;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [Header("GeneratorDifficultySettings")]
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;

    private ObjectPool<Ball> _objectPool;
    
    private float _timeBetweenSpawn;

    public event Action<Ball> OnBallSpawned;
    public event Action<Ball> OnBallReset;

    private void Start()
    {
        _objectPool = new ObjectPool<Ball>(_template, gameObject, 20);
        StartCoroutine(SpawnObjects());
    }

    public void ResetActiveBalls()
    {
        IReadOnlyList<Ball> activeBalls = _objectPool.ActiveObjects();

        foreach (Ball ball in activeBalls)
        {
            OnBallReset?.Invoke(ball);
            ball.Deactivate();
        }
    }

    public void ChangeTimeBetweenSpawn(float difficultyValueInPercentage)
    {
        float inversePercentage = 1 - difficultyValueInPercentage;
        _timeBetweenSpawn = Mathf.Lerp(_minimumSpawnTime, _maximumSpawnTime, inversePercentage);
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if(_objectPool.TryGetObject(out Ball ball))
            {
                ball.transform.position = new Vector2(GetPositionX(), _startingPointOfSpawn.position.y);
                ball.Init();
                OnBallSpawned?.Invoke(ball);
                ball.Activate();
            }

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private float GetPositionX()
    {
        float startingPositionX = _startingPointOfSpawn.position.x;
        return Random.Range(startingPositionX + _minPositionX, startingPositionX + _maxPositionX);
    }
}
