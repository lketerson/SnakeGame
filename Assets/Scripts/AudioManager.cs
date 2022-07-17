using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

//SINGLETON_________________________________________________________________________
public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _soudSource;
    UIManager uIManager;

    private void Awake()
    {
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _soudSource.PlayOneShot(clip);
    }

    public void PlayMusic()
    {
        if (_musicSource.isPlaying)
            _musicSource.Pause();
        else
            _musicSource.Play();
    }
    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }


    public void PlayOnDeath()
    {
        if (_soudSource.isPlaying)
        {
            _musicSource.Stop();
        }
        else
        {
            if(!_musicSource.isPlaying)
                _musicSource.Play();
        }
    }

    public void ForceMusicPlay()
    {
        if(!_soudSource.isPlaying && !_musicSource.isPlaying && !uIManager.menuEnabled)
            _musicSource.Play();
    }
}
