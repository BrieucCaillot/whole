﻿using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string path;
    private string audioName;

    private void Awake()
    {
        if (Instance == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            path = "file://" + Application.streamingAssetsPath + "/Audio/Sounds/";
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string name)
    {
        PauseSound();
        if (!GetActive())
        {
            StartCoroutine(LoadAudio(name));
        }
    }

    public void PauseSound()
    {
        audioSource.Pause();
    }
    
    public void UnPauseSound()
    {
        audioSource.UnPause();
    }
    
    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = path + fileName;
        WWW request = new WWW(audioToLoad);
        return request;
    }

    private IEnumerator LoadAudio(string name)
    {
        audioName = name + ".wav";
        
        WWW request = GetAudioFromFile(path, audioName);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = audioName;

        audioSource.loop = true;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public bool GetActive()
    {
        return audioSource.isPlaying;
    }
}
