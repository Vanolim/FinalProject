using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class BallExplosionParticle : PoolableObject
{
    private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule _particleSystemMain;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystemMain = _particleSystem.main;
    }

    private void Update()
    {
        if(_particleSystem.isPlaying == false)
            Deactivate();
    }

    public void Init(Color color)
    {
        _particleSystemMain.startColor = color;
        _particleSystem.Play();
    }
}
