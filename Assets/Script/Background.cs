using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _music;
    [SerializeField] private List<Sprite> _spritesBackground;
    [SerializeField] private Image _fon;
    [SerializeField] private AudioSource _audioSourceMusic;

    public void UpdateEnvironment()
    {
        TurnOnRandomMusic();
        PutRandomFon();
    }

    public void MuteMusic(bool value)
    {
        _audioSourceMusic.mute = !value;
    }

    private void TurnOnRandomMusic()
    {
        _audioSourceMusic.clip = _music[Random.Range(0, _music.Count)];
        _audioSourceMusic.Play();
    }

    private void PutRandomFon()
    {
        _fon.sprite = _spritesBackground[Random.Range(0, _spritesBackground.Count)];
    }
}
