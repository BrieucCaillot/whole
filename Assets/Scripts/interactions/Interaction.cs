using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interaction : MonoBehaviour
{
    public bool enable = false;
    public bool handleOnComplete = true;
    public InteractionsList InteractionKey;
    public bool hasPicto = false;
    public string action;
    public float delay = 0f;

    public void Enable()
    {
        enable = true;
        
        Invoke("PlayVoiceoverAndSubtitles", 1f);
        if (hasPicto) PictosPositionsManager.Instance.ShowPicto(InteractionKey.ToString());
    }

    public void Disable()
    {
        enable = false;

        if (hasPicto) PictosPositionsManager.Instance.HidePicto();
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
        VoiceoverManager.Instance.PlayVoiceover(GetInteractionName());
        SubtitleManager.Instance.GetSubtitles(GetInteractionName());
    }

    public void InteractionComplete()
    {
        GameManager.Instance.InteractionCompleteHandler();
    }
}