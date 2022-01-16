using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Toggle _muteMusic;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _pause;
    
    public event Action OnRestart;
    public event Action<bool> OnMuteMusic;
    public event Action OnExit;
    public event Action OnResume;
    public event Action OnPause;
    
    private void OnEnable()
    {
        _restart.onClick.AddListener(Restart);
        _muteMusic.onValueChanged.AddListener(MuteMusic);
        _exit.onClick.AddListener(Exit);
        _resume.onClick.AddListener(Resume);
        _pause.onClick.AddListener(Pause);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(Restart);
        _muteMusic.onValueChanged.RemoveListener(MuteMusic);
        _exit.onClick.RemoveListener(Exit);
        _resume.onClick.RemoveListener(Resume);
        _pause.onClick.RemoveListener(Pause);
    }
    
    private void Restart()
    {
        OnRestart?.Invoke();
    }
    
    private void MuteMusic(bool value)
    {
        OnMuteMusic?.Invoke(value);
    }
    
    private void Exit()
    {
        OnExit?.Invoke();
    }

    private void Resume()
    {
        OnResume?.Invoke();
    }

    private void Pause()
    {
        OnPause?.Invoke();
    }
}
