using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarInteraction : Interaction
{
    public override string GetAction() {
        return action = "test";
    }

    public override bool Listen()
    {
        return Input.GetKeyDown("space");
    }
}
