using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsiInteraction : Interaction
{
    public override string GetAction() {
        return action = "vPositionBirds";
    }

    public override bool Listen()
    {
        return PsiGesture.isPsiDone;
    }
}
