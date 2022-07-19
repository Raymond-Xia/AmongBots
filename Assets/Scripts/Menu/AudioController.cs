using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static float volume = 0.5f;
    public static Slider volumeSlider;
    void Awake() {
        int numInstances = FindObjectsOfType<AudioController>().Length;
        if (numInstances > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            AudioListener.volume = volume;
        }
    }

    public void ChangeVolume()
    {
        volume = volumeSlider.value;
        AudioListener.volume = volume;
    }

}
