using System.Collections;
using System.Collections.Generic;
using LitMotion;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    public AudioSource AudioSource;
    private bool isPlaying = false;
    public float start = 0;
    public float end = 0.5f;
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        Instance = this;
        StartMusic();
    }

    public void StartMusic()
    {
        isPlaying = true;
        LMotion.Create(start, end, .5f).Bind(x =>
        {
            if (AudioSource == null) return;
            AudioSource.volume = x;
        });
    }
    
    public void StopMusic()
    {
        LMotion.Create(end, start, .5f).Bind(x =>
        {
            if (AudioSource == null) return;
            AudioSource.volume = x;
        });
    }
}
