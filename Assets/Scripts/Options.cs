using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    private void Start()
    {
        audioMixer.SetFloat("volume",Mathf.Log10 (PlayerPrefs.GetFloat("volume")) *20);
        slider.value = PlayerPrefs.GetFloat("volume", 0.5f);
        //audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
    }

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("volume", Mathf.Log10 (volume) * 20);
        //audioMixer.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);


    }
}
