using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPoseInteraction : Interaction
{
    public override string GetAction() {
        return action = "flyBirds";
    }

    public override bool Listen()
    {
        return TPoseGesture.hasTPose;
    }
}
