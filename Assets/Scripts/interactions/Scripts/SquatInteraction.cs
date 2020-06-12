using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatInteraction : Interaction
{
    public override string GetAction() {
        return action;
    }

    public override bool Listen()
    {
        // return Input.GetMouseButtonDown(0);
        return SquatGesture.isSquatDone;
    }
}
