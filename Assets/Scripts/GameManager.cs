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
    public KinectManager kinectManager;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
            actions.Add("flyBirds", birdsBehavior.flyBirds);
            actions.Add("vPositionBirds", birdsBehavior.vPositionBirds);
            actions.Add("diveBirds", birdsBehavior.diveBirds);
    }
    void Update()
    {
        // Debug.Log(kinectManager.GetUserPosition(1));
    }

    public void InteractionHandler(Interaction interaction)
    {
        actions[interaction.GetAction()]();
    }
    
    public void InteractionCompleteHandler()
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