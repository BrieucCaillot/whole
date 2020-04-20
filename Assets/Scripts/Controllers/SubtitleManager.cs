using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class SubtitleManager : MonoBehaviour
{
    private Text subtitleContent;
    private Array allSubtitles;
    private string path;
    private string jsonString;
    private bool isActive = false;

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
            gameObject.GetComponent<Text>().text = "No more subtitles for this interaction";
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
            gameObject.GetComponent<Text>().text = subtitle.content;
            yield return new WaitForSeconds(subtitle.duration);
            
            if (index == allSubtitles.Length - 1)
            {
                gameObject.GetComponent<Text>().text = "";
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
