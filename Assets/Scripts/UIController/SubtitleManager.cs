using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class SubtitleManager : MonoBehaviour
{
    public AnimationManager _AnimationManager;
    private Text textComponent;
    private Array allSubtitles;
    private string path;
    private string jsonString;
    private bool isActive = false;

    private void Awake()
    {
        textComponent = gameObject.GetComponent<Text>();
    }

    public void GetSubtitles(int interactionNumber)
    {
        if (!isActive)
        {
            GetSubtitlesFromJson(interactionNumber);
            StartCoroutine(DisplaySubtitles());
        }
    }

    private void GetSubtitlesFromJson(int interactionNumber)
    {
        isActive = true;
        try
        {
            path = Application.streamingAssetsPath + "/Subtitles/SubtitlesInteraction" + interactionNumber + ".json";
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
            StartCoroutine(_AnimationManager.FadeTextToFullAlpha(1f, textComponent));
            textComponent.text = subtitle.content;
            
            yield return new WaitForSeconds(subtitle.duration - 1);
            
            StartCoroutine(_AnimationManager.FadeTextToZeroAlpha(1f, textComponent));
            
            yield return new WaitForSeconds(1);
            
            if (index == allSubtitles.Length - 1)
            {
                StartCoroutine(_AnimationManager.FadeTextToZeroAlpha(1f, textComponent));
                
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
