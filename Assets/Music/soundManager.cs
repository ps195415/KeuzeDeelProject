using UnityEngine.Audio;
using System;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public Sound[] _sounds;
    public static soundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        PlaySound("Theme");
    }

    public void StopSound()
    {
        Sound s = Array.Find(_sounds, sound => sound.name == "Theme");
        s.source.Stop();
    }

    public void PlayMusic()
    {
        PlaySound("Theme");
    }

    public void PlaySound(String name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

}
