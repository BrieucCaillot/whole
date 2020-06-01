using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInteraction : Interaction
{
    public override string GetAction() {
        return action = "vPositionBirds";
    }

    public override bool Listen()
    {
        return JumpGesture.hasJumped;
    }
}
