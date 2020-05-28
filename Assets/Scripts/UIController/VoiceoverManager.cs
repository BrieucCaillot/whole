using System.Collections;
using UnityEngine;

public class VoiceoverManager : MonoBehaviour
{
    public static VoiceoverManager Instance;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string path;
    private string audioName;

    private void Awake()
    {
        if (Instance == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            path = "file://" + Application.streamingAssetsPath + "/Audio/Voiceover/";
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayVoiceover()
    {
        StartCoroutine(LoadAudio());
    }
    
    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = path + fileName;
        WWW request = new WWW(audioToLoad);
        return request;
    }

    private IEnumerator LoadAudio()
    {
        audioName = "Voiceover" + GameManager.Instance.InteractionNumber + ".wav";
        
        WWW request = GetAudioFromFile(path, audioName);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = audioName;
        
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public bool GetActive()
    {
        return audioSource.isPlaying;
    }
}
