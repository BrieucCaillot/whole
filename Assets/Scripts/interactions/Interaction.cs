using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Interaction : MonoBehaviour
{
    public bool enable;
    public string action;
	
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
    
    public void PlayVoiceoverAndSubtitles()
    {
        VoiceoverManager.Instance.PlayVoiceover(action);
        SubtitleManager.Instance.GetSubtitles(action);
    }

    public void StopVoiceoverAndSubtitles()
    {

    }

    public void DisplayPictogram()
    {
        PictosPositionsManager.Instance.Position(action);
    }

    public void RemovePictogram()
    {
        // PictosPositionsManager.Instance.Position(action);
    }
}
