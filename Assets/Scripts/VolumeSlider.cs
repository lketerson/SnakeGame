using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField] Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.ChangeMasterVolume(_slider.value);
        _slider.onValueChanged.AddListener(value => AudioManager.Instance.ChangeMasterVolume(value));
    }


}
