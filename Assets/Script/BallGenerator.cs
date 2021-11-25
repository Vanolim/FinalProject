using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Vector2 _startingPointOfSpawn;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private CatchingTheBall _handScoreEvents;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;

    private float _timeBetweenSpawn;

    private void Start()
    {
        Initialize(_template);
        StartCoroutine(SpawnObjects());
    }

    public void ResetGenerator()
    {
        List<Ball> activeGameObject = ReturnActiveObjectsPool();

        foreach (var item in activeGameObject)
        {
            _handScoreEvents.UnsubscribeToTheBallButtonEvent(item);
            item.gameObject.SetActive(false);
        }
    }

    public void SetTimeBetweenSpawn(float difficultyValueInPercentage)
    {
        float inversePercentage = 1 - difficultyValueInPercentage;
        _timeBetweenSpawn = Mathf.Lerp(_minimumSpawnTime, _maximumSpawnTime, inversePercentage);
    }

    private float SetTheSpawnPointToRandomPositionX()
    {
        return Random.Range(_startingPointOfSpawn.x + _minPositionX, _startingPointOfSpawn.x + _maxPositionX);
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if(TryGetObject(out GameObject ball))
            {
                ball.transform.position = new Vector2(SetTheSpawnPointToRandomPositionX(), _startingPointOfSpawn.y);
                _handScoreEvents.SubscribeToTheBallCaughtEvent(ball.GetComponent<Ball>());
                ball.SetActive(true);
            }

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
