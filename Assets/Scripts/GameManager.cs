using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{

    // public Dictionary<string, Action> actions = new Dictionary<string, Action>()
    // {
    //     {"vPosition", () => BirdsBehavior.vPosition() },
    //     {"dive", () => BirdsBehavior.dive() }
    // };


    public InteractionManager interactionManager;
    public BirdsBehavior birdsBehavior;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionHandler(Interaction interaction)
    {
        // actions[interaction.action]();
    }

    void InteractionCompleteHandler()
    {
        // int currentIndex = InteractionManager.GetIndex();
        // InteractionManager.SetIndex(currentIndex + 1);
    }
}