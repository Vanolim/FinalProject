using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
