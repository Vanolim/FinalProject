using UnityEngine;

public class TimeState : MonoBehaviour
{
    public void Stop()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
