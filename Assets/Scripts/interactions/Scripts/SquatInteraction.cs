using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatInteraction : Interaction
{
    public override string GetAction() {
        return action = "diveBirds";
    }

    public override bool Listen()
    {
        return SquatGesture.isSquatDone;
    }
}
