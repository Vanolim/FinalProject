using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : ObjectPool
{
    [SerializeField] private Ball _template;
    [SerializeField] private Vector2 _startingPointOfSpawn;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private BallCatchHandling _handScoreEvents;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;

    private float _timeBetweenSpawn;

    private void Start()
    {
        Initialize(_template);
        StartCoroutine(SpawnObjects());
    }

    public void ResetActiveBalls()
    {
        List<Ball> activeGameObjects = ReturnActiveObjectsPool();

        foreach (var item in activeGameObjects)
        {
            _handScoreEvents.UnsubscribeToCatchTheBall(item);
            item.gameObject.SetActive(false);
        }
    }

    public void SetTimeBetweenSpawn(float difficultyValueInPercentage)
    {
        float inversePercentage = 1 - difficultyValueInPercentage;
        _timeBetweenSpawn = Mathf.Lerp(_minimumSpawnTime, _maximumSpawnTime, inversePercentage);
    }

    private float SetThePositionX()
    {
        return Random.Range(_startingPointOfSpawn.x + _minPositionX, _startingPointOfSpawn.x + _maxPositionX);
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if(TryGetObject(out Ball ball))
            {
                ball.transform.position = new Vector2(SetThePositionX(), _startingPointOfSpawn.y);
                _handScoreEvents.SubscribeToCatchTheBall(ball);
                ball.SetState();
                ball.gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
