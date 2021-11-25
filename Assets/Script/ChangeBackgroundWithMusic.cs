using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ChangeBackgroundWithMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _music;
    [SerializeField] private List<Sprite> _SpritesBackground;
    [SerializeField] private Image _background;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void UpdateEnvironment()
    {
        TurnOnRandomMusic();
        PutRandomBackground();
    }

    public void SwitchMusic(bool value)
    {
        if(value == true)
        {
            _audioSource.mute = false;
        }
        else
        {
            _audioSource.mute = true;
        }
    }

    private void TurnOnRandomMusic()
    {
        _audioSource.clip = _music[Random.Range(0, _music.Count)];
        _audioSource.Play();
    }

    private void PutRandomBackground()
    {
        _background.sprite = _SpritesBackground[Random.Range(0, _SpritesBackground.Count)];
    }
}
