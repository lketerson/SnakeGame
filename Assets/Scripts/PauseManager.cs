using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    bool isPaused;
    public void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            AudioManager.Instance.ChangeMasterVolume(0f);
            Time.timeScale = 0;
        }
        else
        {
            
            AudioManager.Instance.ChangeMasterVolume(.5f);
            Time.timeScale = 1;
        }

        
        
    }
    
}
