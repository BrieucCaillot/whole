using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string path;
    private string audioName;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        path = "file://" + Application.streamingAssetsPath + "/Audio/";
    }

    public void PlayAudio(int interactionNumber)
    {
        if (!getActive())
        {
            StartCoroutine(LoadAudio(interactionNumber));
        }
    }
    
    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = path + fileName;
        WWW request = new WWW(audioToLoad);
        return request;
    }

    private IEnumerator LoadAudio(int interactionNumber)
    {
        audioName = "AudioInteraction" + interactionNumber + ".wav";
        
        WWW request = GetAudioFromFile(path, audioName);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = audioName;
        
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public bool getActive()
    {
        return audioSource.isPlaying;
    }
}
