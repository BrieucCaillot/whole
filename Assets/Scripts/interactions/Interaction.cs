using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Interaction : MonoBehaviour
{
    public bool enable;
    public string action;
    //option1
    public string audioName;
	
    public void Enable() 
    {
        enable = true;
        //play voice/sbtitles and pictos
    }

    public void Disable()
    {
        enable = false;
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

    public virtual string GetInfo() {
        return "";
    }
    
    public virtual void PlayVoiceoverAndSubtitles() {
        // Play voiceover & subtitle
        VoiceoverManager.Instance.PlayVoiceover(action);
        SubtitleManager.Instance.GetSubtitles(action);
        // Play picto interaction
        // faut surement séparer l'appel du picto à cet endroit
        PictosPositionsManager.Position("V");

    }
}
