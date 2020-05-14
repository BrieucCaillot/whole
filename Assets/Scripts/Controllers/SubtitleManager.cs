using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class SubtitleManager : MonoBehaviour
{
    public static SubtitleManager Instance;
    private Text textComponent;
    private Array allSubtitles;
    private string path;
    private string jsonString;
    private bool isActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            textComponent = gameObject.GetComponent<Text>();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    
    public void GetSubtitles()
    {
        GetSubtitlesFromJson();
        StartCoroutine(DisplaySubtitles());
    }

    private void GetSubtitlesFromJson()
    {
        isActive = true;
        try
        {
            path = Application.streamingAssetsPath + "/Subtitles/SubtitlesInteraction" + GameManager.Instance.InteractionNumber + ".json";
            jsonString = File.ReadAllText(path);
        }
        catch (FileNotFoundException e)
        {
            Debug.Log(e);
            textComponent.text = "No more subtitles for this interaction";
            return;
        }
        
        Subtitles subtitlesInJson = JsonUtility.FromJson<Subtitles>(jsonString);
        allSubtitles = subtitlesInJson.subtitles;
    }

    IEnumerator DisplaySubtitles()
    {
        int index = 0;

        foreach (Subtitle subtitle in allSubtitles)
        {
            StartCoroutine(AnimationManager.Instance.FadeTextToFullAlpha(1f, textComponent));
            textComponent.text = subtitle.content;
            
            yield return new WaitForSeconds(subtitle.duration - 1);
            
            StartCoroutine(AnimationManager.Instance.FadeTextToZeroAlpha(1f, textComponent));
            
            yield return new WaitForSeconds(1);
            
            if (index == allSubtitles.Length - 1)
            {
                StartCoroutine(AnimationManager.Instance.FadeTextToZeroAlpha(1f, textComponent));
                
                textComponent.text = "";
                allSubtitles = null;
                isActive = false;
            }

            index++;
        }
    }
    
    public bool GetActive()
    {
        return isActive;
    }
}


[System.Serializable] 
public class Subtitles
{
    public Subtitle[] subtitles;
}


[System.Serializable] 
public class Subtitle
{
    public string content;
    public int duration;
}
