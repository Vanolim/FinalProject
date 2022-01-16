using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fon : MonoBehaviour
{
    [SerializeField] private Image _fon;
    [SerializeField] private List<Sprite> _spritesFon;
    
    public void UpdateEnvironment()
    {
        PutRandomFon();
    }
    
    private void PutRandomFon()
    {
        _fon.sprite = _spritesFon[Random.Range(0, _spritesFon.Count)];
    }
}
