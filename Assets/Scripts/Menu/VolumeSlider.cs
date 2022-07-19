using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private AudioController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find(Constants.AUDIO_CONTROLLER_OBJECT).GetComponent<AudioController>();
        Slider slider = gameObject.GetComponent<Slider>();
        AudioController.volumeSlider = gameObject.GetComponent<Slider>();
        slider.value = AudioController.volume;
    }

    public void ChangeVolume ()
    {
        controller.ChangeVolume();
    }

}
