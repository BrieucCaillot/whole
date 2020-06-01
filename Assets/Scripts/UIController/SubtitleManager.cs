using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class SubtitleManager : MonoBehaviour
{
    private static Text textComponent;
    private static Array allSubtitles;
    private static string path;
    private static string jsonString;
    private static bool isActive = false;

    private void Start()
    {
        textComponent = gameObject.GetComponent<Text>();
    }

    public void GetSubtitles()
    {
        GetSubtitlesFromJson();
        StartCoroutine(DisplaySubtitles());
    }

    private static void GetSubtitlesFromJson()
    {
        isActive = true;
        try
        {
            path = Application.streamingAssetsPath + "/Subtitles/SubtitlesInteraction" + GameManager.Instance.index + ".json";
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
            StartCoroutine(AnimationManager.FadeTextToFullAlpha(1f, textComponent));
            textComponent.text = subtitle.content;
            
            yield return new WaitForSeconds(subtitle.duration - 1);
            
            StartCoroutine(AnimationManager.FadeTextToZeroAlpha(1f, textComponent));
            
            yield return new WaitForSeconds(1);
            
            if (index == allSubtitles.Length - 1)
            {
                StartCoroutine(AnimationManager.FadeTextToZeroAlpha(1f, textComponent));
                
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
