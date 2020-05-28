using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "interactions/inputInteraction")]
public class InputInteraction : Interaction
{
    // public bool enable = true;

    public String action = "VPosition";

    // public override void Awake() {
    //     Debug.Log("start");
        
    // }

    public override bool Listen()
    {
        return Input.GetKeyDown("space");
    }
}
