using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interaction : MonoBehaviour
{
    public bool enable = false;
    public bool isAudioComplete = false;
    public bool isTimeoutCompleted = false;

    public string action;
    public bool hasPicto = false;
    public float audioDuration = 0f;
    public float delay = 0f;
    public bool handleOnComplete = true;
    public InteractionsList InteractionKey;

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
        Debug.Log("Trigger " + action);

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
        VoiceoverManager.Instance.PlayVoiceover(GetInteractionName());
        SubtitleManager.Instance.GetSubtitles(GetInteractionName());
        Invoke("AudioCompleteHandler", audioDuration);
    }

    public void InteractionComplete()
    {
        if (isAudioComplete && isTimeoutCompleted) {
            Debug.Log("Interaction Completed " + action);
            GameManager.Instance.InteractionCompleteHandler();
        };
    }

    public void AudioCompleteHandler()
    {
        Debug.Log("Audio Completed " + action);

        isAudioComplete = true;
        InteractionComplete();
    }

    public void TimeoutCompletedHandler()
    {
        Debug.Log("Timeout Completed " + action);

        isTimeoutCompleted = true;
        InteractionComplete();
    }
}