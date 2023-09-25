using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public Sound[] sounds;

    private Character_Move thePlayer;

    private void Awake()
    {
        foreach (var s in sounds)
        {
            thePlayer = FindObjectOfType<Character_Move>();
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Stop();

    }

    public void Volume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.volume -= Time.deltaTime / 5;
        s.source.pitch -= Time.deltaTime / 7;

    }



}
