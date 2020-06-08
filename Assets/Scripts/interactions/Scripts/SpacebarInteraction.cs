using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarInteraction : Interaction
{
    void Start()
    {
        action = "test";
    }

    public override string GetAction() {
        return action;
    }

    public override bool Listen()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayVoiceoverAndSubtitles();
        }

        return Input.GetKeyDown("space");
    }
}
