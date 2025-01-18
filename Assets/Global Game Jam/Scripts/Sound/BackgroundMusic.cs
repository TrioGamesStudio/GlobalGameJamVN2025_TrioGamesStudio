using System.Collections;
using System.Collections.Generic;
using LitMotion;
using Mono.Cecil;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    public AudioSource AudioSource;
    private bool isPlaying = false;
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        Instance = this;
        StartMusic();
    }

    public void StartMusic()
    {
        isPlaying = true;
        LMotion.Create(0, 1, .5f).Bind(x =>
        {
            if (AudioSource == null) return;
            AudioSource.volume = x;
        });
    }
    
    public void StopMusic()
    {
        LMotion.Create(1, 0, .5f).Bind(x =>
        {
            if (AudioSource == null) return;
            AudioSource.volume = x;
        });
    }
}
