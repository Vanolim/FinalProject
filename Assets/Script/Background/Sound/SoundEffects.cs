using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private BallHandler _ballHandler;
    [SerializeField] private AudioSource _positive;
    [SerializeField] private AudioSource _negative;

    private void OnEnable()
    {
        _ballHandler.OnSuccess += PlayPositiveSound;
        _ballHandler.OnFailed += PlayNegativeSound;
    }

    private void OnDisable()
    {
        _ballHandler.OnSuccess -= PlayPositiveSound;
        _ballHandler.OnFailed -= PlayNegativeSound;
    }

    private void PlayPositiveSound()
    {
        _positive.Play();
    }
    private void PlayNegativeSound()
    {
        _negative.Play();
    }
}
