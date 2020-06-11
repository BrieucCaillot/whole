using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interaction : MonoBehaviour
{
    private bool enable = false;
    public bool handleOnComplete = true;
    public InteractionsList InteractionKey;
    public bool hasPicto = false;
    public string action;
    public float delay = 0f;

    public void Enable()
    {
        enable = true;

        Debug.Log("listening " + action);

        Invoke("PlayVoiceoverAndSubtitles", 1f);
        if (hasPicto) TogglePictogram();
    }

    public void Disable()
    {
        enable = false;

        if (hasPicto) TogglePictogram();
    }

    public bool IsEnabled()
    {
        return enable;
    }

    public void Trigger()
    {
        if (handleOnComplete)
        {
            Invoke("InteractionComplete", delay);
        }
        if (hasPicto) {
            TogglePictogram();
        }
        
        
    }

    public virtual bool Listen()
    {
        return false;
    }

    public virtual string GetAction()
    {
        return action;
    }

    public string GetInteractionName()
    {
        return GetEnumMemberAttrValue.Instance.Value(typeof(InteractionsList), InteractionKey);
    }

    public void PlayVoiceoverAndSubtitles()
    {
        // Debug.Log("Play Voice " + action);
        if(GetInteractionName() == "01_default") return;

        VoiceoverManager.Instance.PlayVoiceover(GetInteractionName());
        SubtitleManager.Instance.GetSubtitles(GetInteractionName());
    }

    public void TogglePictogram()
    {
        PictosPositionsManager.Instance.Position(InteractionKey.ToString());
    }

    public void InteractionComplete()
    {
        Debug.Log("complete  " + action);
        GameManager.Instance.InteractionCompleteHandler();
    }
}