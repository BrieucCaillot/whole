using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class SubtitlesScript : MonoBehaviour
{
    private Text subtitleContent;
    private string path;
    private string jsonString;
    private int interactionNumber = 0;
    private bool isActive = false;
    private Array allSubtitles;

    public void GetSubtitles()
    {
        if (!isActive)
        {
            GetSubtitlesFromJson();
            StartCoroutine(DisplaySubtitles());
        }
    }

    private void GetSubtitlesFromJson()
    {
        isActive = true;
        interactionNumber++;
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
}

[System.Serializable] 
public class Subtitles
{
    public Subtitle[] subtitles;
}


[System.Serializable] 
public class Subtitle
{
    public int interaction;
    public string content;
    public int duration;
}
