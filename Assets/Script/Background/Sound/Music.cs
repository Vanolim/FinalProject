using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Music : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _music;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private MenuButtonHandler _menuButtonHandler;

    private void OnEnable()
    {
        _menuButtonHandler.OnMuteMusic += SwitchMusicState;
    }

    private void OnDisable()
    {
        _menuButtonHandler.OnMuteMusic -= SwitchMusicState;
    }

    public void UpdateEnvironment()
    {
        TurnOnRandomMusic();
    }
    
    private void TurnOnRandomMusic()
    {
        _audioSourceMusic.clip = _music[Random.Range(0, _music.Count)];
        _audioSourceMusic.Play();
    }
    
    private void SwitchMusicState(bool isMuted)
    {
        _audioSourceMusic.mute = !isMuted;
    }
}
