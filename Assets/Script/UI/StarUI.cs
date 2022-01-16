using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StarUI : MonoBehaviour
{
    [SerializeField] private MenuButtonHandler _menuButtonHandler;
    
    private Transform _startTransform;
    private Animator _animator;

    private void OnEnable()
    {
        _menuButtonHandler.OnRestart += StopAnimation;
    }

    private void OnDisable()
    {
        _menuButtonHandler.OnRestart -= StopAnimation;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _startTransform = transform;
    }

    public void ActivateAnimation()
    {
        _animator.enabled = true;
    }

    private void StopAnimation()
    {
        _animator.enabled = false;
        ResetRotationValues();
    }
    
    private void ResetRotationValues()
    {
        _startTransform.rotation = Quaternion.identity;
    }
}
