using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private static AudioSource audioSource;
    private static AudioClip audioClip;
    private string path;
    private string audioName;

    /// <summary>
    /// Create Audio component on Awake
    /// </summary>
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

    /// <summary>
    /// Play sound with coroutine
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(string name)
    {
        PauseSound();
        if (!IsPlaying())
        {
            StartCoroutine(LoadAudio(name));
        }
    }

    /// <summary>
    /// Pause sound
    /// </summary>
    public static void PauseSound()
    {
        audioSource.Pause();
    }
    
    /// <summary>
    /// Unpause sound
    /// </summary>
    public static void UnPauseSound()
    {
        audioSource.UnPause();
    }
    
    /// <summary>
    /// Get audio file from path & filename
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = path + fileName;
        WWW request = new WWW(audioToLoad);
        return request;
    }

    /// <summary>
    /// Load audio & play audio from source file
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Returns if audio is playing
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
