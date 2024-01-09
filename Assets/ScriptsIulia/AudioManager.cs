using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public float musicVolume;
    public float efectVolume;

    void Awake()
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

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

    }

    private void Start()
    {
        //Play("MainMenu");

    }
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null)
        {
            Debug.Log("Sound: " + sound.name + " not found");
            return;
        }

        //if (PauseMenu.GameIsPaused)
        //{
        //    sound.source.pitch *= .5f;
        //}

        sound.source.Play();
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found");
            return;
        }

        s.source.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeVolumenMusic(float volum)
    {
        foreach (Sound sound in sounds)
        {
            sound.source.volume = sound.volume * volum;
        }
    }
}
