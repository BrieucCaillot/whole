using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "interactions/kinectInteraction")]
public class KinectInteraction : Interaction
{
    // public bool enable = true;

    public override bool Listen()
    {
        return false;
    }
}
