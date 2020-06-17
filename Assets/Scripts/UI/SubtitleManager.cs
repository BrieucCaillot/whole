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

    /// <summary>
    /// Create text component on start
    /// </summary>
    private void Start()
    {
        textComponent = gameObject.GetComponent<Text>();
        textComponent.DOFade(0, 1f);
    }

    /// <summary>
    /// Call GetSubtitles & DisplaySubtitles
    /// </summary>
    /// <param name="actionName"></param>
    public void GetSubtitles(string actionName)
    {
            GetSubtitlesFromJson(actionName);
            StartCoroutine(DisplaySubtitles());    
    }

    /// <summary>
    /// Get json subtitles from streaming assets
    /// </summary>
    /// <param name="actionName"></param>
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

    /// <summary>
    ///  Display subtitles once 
    /// </summary>
    /// <returns></returns>
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
    
    /// <summary>
    /// Returns if subtitle is active
    /// </summary>
    /// <returns></returns>
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
