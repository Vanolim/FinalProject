using System.Collections.Generic;
using UnityEngine;

public class BallExplosionParticleGenerator : MonoBehaviour
{
    [SerializeField] private BallExplosionParticle _template;
    [SerializeField] private BallHandler _ballHandler;

    private ObjectPool<BallExplosionParticle> _objectPool;

    private void OnEnable()
    {
        _ballHandler.OnBallCaught += GetDataToSpawnParticle;
    }

    private void OnDisable()
    {
        _ballHandler.OnBallCaught -= GetDataToSpawnParticle;
    }

    private void Start()
    {
        _objectPool = new ObjectPool<BallExplosionParticle>(_template, gameObject, 20);
    }

    private void GetDataToSpawnParticle(Ball ball)
    {
        SpawnParticle(ball.gameObject.transform.position, ball.GetColor());
    }

    private void SpawnParticle(Vector2 spawnPosition, Color particleColor)
    {
        if(_objectPool.TryGetObject(out BallExplosionParticle particle))
        {
            particle.transform.position = spawnPosition;
            particle.Activate();
            particle.Init(particleColor);
        }
    }

    public void ResetActiveParticle()
    {
        IReadOnlyList<BallExplosionParticle> activeParticle = _objectPool.ActiveObjects();

        foreach (BallExplosionParticle item in activeParticle)
        {
            item.Deactivate();
        }
    }
}
