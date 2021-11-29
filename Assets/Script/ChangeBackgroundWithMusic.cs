using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundWithMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _music;
    [SerializeField] private List<Sprite> _SpritesBackground;
    [SerializeField] private Image _background;
    [SerializeField] private AudioSource _audioSourceMusic;

    public void UpdateEnvironment()
    {
        TurnOnRandomMusic();
        PutRandomBackground();
    }

    public void SwitchMusic(bool value)
    {
        if(value == true)
        {
            _audioSourceMusic.mute = false;
        }
        else
        {
            _audioSourceMusic.mute = true;
        }
    }

    private void TurnOnRandomMusic()
    {
        _audioSourceMusic.clip = _music[Random.Range(0, _music.Count)];
        _audioSourceMusic.Play();
    }

    private void PutRandomBackground()
    {
        _background.sprite = _SpritesBackground[Random.Range(0, _SpritesBackground.Count)];
    }
}
