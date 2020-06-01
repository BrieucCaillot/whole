using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public int index = 0;

    //managers
    public InteractionManager interactionManager;
    public VoiceoverManager voiceoverManager;
    public SubtitleManager subtitleManager;

    //behaviors
    public BirdsBehavior birdsBehavior;

    public Dictionary<string, Action> actions = new Dictionary<string, Action>()
    {
        // {"vPosition", () => BirdsBehavior.vPosition() },
        // {"dive", () => BirdsBehavior.dive() }
    };

    void Start()
    {
        index = interactionManager.GetIndex();    
    }

    public void InteractionHandler(Interaction interaction)
    {
        // actions[interaction.action]();
    }
    
    void InteractionCompleteHandler()
    {
        int currentIndex = interactionManager.GetIndex();
        interactionManager.SetIndex(currentIndex + 1);
    }


    // public static void NewInteraction()
    // {
    //     if (!VoiceoverManager.Instance.IsPlaying() && !SubtitleManager.Instance.IsActive())
    //     {
    //         InteractionNumber++;
    //         VoiceoverManager.Instance.PlayVoiceover();
    //         SubtitleManager.Instance.GetSubtitles();
    //     }
    // }
}