using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPoseInteraction : Interaction
{
    public override string GetAction() {
        return action;
    }

    public override bool Listen()
    {
        // return Input.GetMouseButtonDown(0);
        return TPoseGesture.isTPoseDone;
    }
}
