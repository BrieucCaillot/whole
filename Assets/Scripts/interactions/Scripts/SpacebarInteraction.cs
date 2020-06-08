using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarInteraction : Interaction
{
    public override string GetAction() {
        return action = "SpacebarInteraction";
    }

    public override bool Listen()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayVoiceoverAndSubtitles(GetAction());
        }

        return Input.GetKeyDown("space");
    }
}
