using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound Asset",fileName = "Sound Data")]
public class SoundData : ScriptableObject
{
    public AudioClip clip;
    public float volume;
    public float pitch = 1f;
    [Button]
    public void PlayTest()
    {
        this.PlayAudio();
    }
}

public static class SoundUltis
{
    public static void PlayAudio(this SoundData soundData)
    {
        var go = new GameObject($"Audio Source {soundData.clip.name}", typeof(AudioSource));
        var audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = soundData.clip;
        audioSource.playOnAwake = false;
        audioSource.volume = soundData.volume;
        audioSource.pitch = soundData.pitch;
        audioSource.Play();
        GameObject.DontDestroyOnLoad(audioSource.gameObject);
        GameObject.Destroy(audioSource.gameObject, audioSource.clip.length);

    }
}