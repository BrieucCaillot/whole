using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Interaction : MonoBehaviour
{
    public bool enable;
    public string action;
    public float delay = 5f;
	
    public void Enable() 
    {
        enable = true;

        PlayVoiceoverAndSubtitles();
        DisplayPictogram();
    }

    public void Disable()
    {
        enable = false;
        
        RemovePictogram();
        StopVoiceoverAndSubtitles();
    }

    public bool IsEnabled()
    {
        return enable;
    }

    public virtual bool Listen()
    {
        return false;
    }

    public virtual string GetAction(){
        return action;
    }

    IEnumerator Timeout()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(delay);

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    
    public void PlayVoiceoverAndSubtitles()
    {
        // VoiceoverManager.Instance.PlayVoiceover(action);
        // SubtitleManager.Instance.GetSubtitles(action);
    }

    public void StopVoiceoverAndSubtitles()
    {

    }

    public void DisplayPictogram()
    {
        // PictosPositionsManager.Instance.Position(action);
    }

    public void RemovePictogram()
    {
        // PictosPositionsManager.Instance.Position(action);
    }
}
