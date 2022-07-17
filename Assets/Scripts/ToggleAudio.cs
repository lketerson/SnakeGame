using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic;
    // Start is called before the first frame update
    public void Toggle()
    {
        if (_toggleMusic)
        {
            AudioManager.Instance.ToggleMusic();
        }
    }
}
