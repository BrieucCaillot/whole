using UnityEngine;

public class SpacebarInteraction : Interaction
{
    public override string GetAction() {
        return action;
    }

    public override bool Listen()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
