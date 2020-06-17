using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interaction : MonoBehaviour
{
    private bool enable = false;
    private bool isAudioComplete = false;
    private bool isTimeoutCompleted = false;

    public string action;
    public bool hasPicto = false;
    public float audioDuration = 0f;
    public float delay = 0f;
    public bool handleOnComplete = true;
    public InteractionsList InteractionKey;

    public void Enable()
    {
        // Debug.Log("Listening " + action);
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
        // Debug.Log("Trigger " + action);

        if (handleOnComplete)
        {
            Invoke("TimeoutCompletedHandler", delay);
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
        if(GetInteractionName() == "00_default") return;

        VoiceoverManager.Instance.PlayVoiceover(GetInteractionName());
        SubtitleManager.Instance.GetSubtitles(GetInteractionName());
        Invoke("AudioCompleteHandler", audioDuration);
    }

    public void InteractionComplete()
    {
        if (isAudioComplete && isTimeoutCompleted) {
            // Debug.Log("Interaction Completed " + action);
            GameManager.Instance.InteractionCompleteHandler();
        };
    }

    public void AudioCompleteHandler()
    {
        isAudioComplete = true;
        InteractionComplete();
    }

    public void TimeoutCompletedHandler()
    {
        isTimeoutCompleted = true;
        InteractionComplete();
    }
}