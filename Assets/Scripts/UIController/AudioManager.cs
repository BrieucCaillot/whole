using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private static AudioSource audioSource;
    private static AudioClip audioClip;
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
        if (!IsPlaying())
        {
            StartCoroutine(LoadAudio(name));
        }
    }

    public static void PauseSound()
    {
        audioSource.Pause();
    }
    
    public static void UnPauseSound()
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

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
