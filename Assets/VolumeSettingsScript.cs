using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider BGMSliderGameplay;
    public Slider SFXSliderGameplay;

    void Update()
    {

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("BGMVolume"))
        {
            LoadBGMVolume();
        }
        else
        {
            SetBGMVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }
    }

    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        BGMSliderGameplay.value = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        SFXSliderGameplay.value = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetBGMVolumeGameplay()
    {
        float volume = BGMSliderGameplay.value;
        BGMSlider.value = BGMSliderGameplay.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolumeGameplay()
    {
        float volume = SFXSliderGameplay.value;
        SFXSlider.value = SFXSliderGameplay.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void LoadBGMVolume()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        BGMSliderGameplay.value = PlayerPrefs.GetFloat("BGMVolume");
        SetBGMVolume();
        SetBGMVolumeGameplay();
    }

    public void LoadSFXVolume()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SFXSliderGameplay.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
        SetSFXVolumeGameplay();
    }
}
