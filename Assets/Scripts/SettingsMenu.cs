using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider sliderMusic;
    public Slider sliderSFX;
    public Toggle toggleMusic;
    public Toggle toggleSFX;

    void Awake()
    {

        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            sliderSFX.value = PlayerPrefs.GetFloat("SFX Volume");
        }

        if (PlayerPrefs.HasKey("Music Volume"))
        {
            sliderMusic.value = PlayerPrefs.GetFloat("Music Volume");
        }


        if (PlayerPrefs.HasKey("SFX Mute"))
        {
            if (PlayerPrefs.GetInt("SFX Mute") == 1)
            {
                toggleMusic.isOn = true;
            }
            if (PlayerPrefs.GetInt("SFX Mute") == 0)
            {
                toggleMusic.isOn = false;
            }
        }
        if (PlayerPrefs.HasKey("Volume Mute"))
        {
            if (PlayerPrefs.GetInt("Music Mute") == 1)
            {
                toggleSFX.isOn = true;
            }
            if (PlayerPrefs.GetInt("Music Mute") == 0)
            {
                toggleSFX.isOn = false;
            }
        }
    }

    public void SetVolumeMusic (float volume)
    {
        Debug.Log(volume);

        AudioManager.instance.SetVolume("MusicVolume", volume);
        PlayerPrefs.SetFloat("Music Volume", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        AudioManager.instance.SetVolume("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFX Volume", volume);

    }

    public void MuteMusic(bool mute)
    {
        AudioManager.instance.Mute("Theme", mute);
        if (mute)
        {
            PlayerPrefs.SetInt("Music Mute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Music Mute", 0);
        }
    }

    public void MuteSFX(bool mute)
    {
        AudioManager.instance.Mute("GhostSound", mute);

        if(mute)
        {
            PlayerPrefs.SetInt("SFX Mute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SFX Mute", 0);
        }

    }
}
