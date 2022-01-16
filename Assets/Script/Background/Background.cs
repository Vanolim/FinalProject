using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Fon _fon;
    [SerializeField] private Music _music;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        _fon.UpdateEnvironment();
        _music.UpdateEnvironment();
    }
}
