using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer audioMixer;

    public static AudioManager instance;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
            s.source.outputAudioMixerGroup = s.group;
        }

        Sound s1 = Array.Find(sounds, sound => sound.name == "GhostSound");
        if (PlayerPrefs.HasKey("SFX Volume"))
        {
            s1.source.volume = PlayerPrefs.GetFloat("SFX Volume");
        }
        if (PlayerPrefs.HasKey("SFX Mute"))
        {
            if (PlayerPrefs.GetInt("SFX Mute") == 1)
            {
                s1.source.mute = false;
            }
            else
            {
                s1.source.mute = true;
            }
        }

        Sound s2 = Array.Find(sounds, sound => sound.name == "Theme");
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            s2.source.volume = PlayerPrefs.GetFloat("Music Volume");
        }
        if (PlayerPrefs.HasKey("Music Mute"))
        {
            if (PlayerPrefs.GetInt("Music Mute") == 1)
            {
                s2.source.mute = false;
            }
            else
            {
                s2.source.mute = true;
            }
        }




        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


    public void SetVolume(string name, float volume)
    {
        audioMixer.SetFloat(name, volume);
    }


    public void Mute(string name, bool mute)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.mute = !mute;
    }
}
