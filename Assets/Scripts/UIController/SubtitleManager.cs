using System;
using System.Collections;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class SubtitleManager : Singleton<SubtitleManager>
{
    private static Text textComponent;
    private static Array allSubtitles;
    private static string path;
    private static string jsonString;
    private static bool isActive = false;

    private void Start()
    {
        textComponent = gameObject.GetComponent<Text>();
        textComponent.DOFade(0, 1f);
    }

    public void GetSubtitles(string actionName)
    {
        if (!IsActive())
        {
            GetSubtitlesFromJson(actionName);
            StartCoroutine(DisplaySubtitles());    
        }
    }

    private static void GetSubtitlesFromJson(string actionName)
    {
        isActive = true;
        try
        {
            path = Application.streamingAssetsPath + "/Subtitles/" + actionName + ".json";
            jsonString = File.ReadAllText(path);
        }
        catch (FileNotFoundException e)
        {
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
            textComponent.DOFade(1, 1f);
            textComponent.text = subtitle.content;
            
            yield return new WaitForSeconds(subtitle.duration - 1);
            
            textComponent.DOFade(0, 1f);
            
            yield return new WaitForSeconds(1);
            
            if (index == allSubtitles.Length - 1)
            {
                textComponent.DOFade(0, 1f);
                
                textComponent.text = "";
                allSubtitles = null;
                isActive = false;
            }

            index++;
        }
    }
    
    public bool IsActive()
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
