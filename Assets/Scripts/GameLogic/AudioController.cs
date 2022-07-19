using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource[] sounds;
    public Slider musicSlider;
    public Slider sfxSlider;
    public List<AudioSource> activeObjectSounds;

    // Start is called before the first frame update
    void Start()
    {
        music.volume = 0.5f;
        foreach (AudioSource sound in sounds)
        {
            sound.volume = 0.5f;
        }
    }

    public void ChangeMusicVolume()
    {
        music.volume = musicSlider.value;
    }

    public void ChangeSFXVolume()
    {
        foreach (AudioSource sound in sounds)
        {
            sound.volume = sfxSlider.value;
        }
        activeObjectSounds = new List<AudioSource>(transform.GetComponentsInChildren<AudioSource>());
        activeObjectSounds.Remove(transform.GetComponent<AudioSource>());
        foreach (AudioSource sound in activeObjectSounds)
        {
            sound.volume = sfxSlider.value;
        }
    }
}
