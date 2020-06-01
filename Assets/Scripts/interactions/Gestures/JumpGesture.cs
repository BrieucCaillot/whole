using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGesture : Gestures
{
    private static bool jump;

    public static bool hasJumped{
        get { return jump; }
    }

    public override void UserDetected(uint userId, int userIndex) {
		  GameManager.Instance.kinectManager.DetectGesture(userId, KinectGestures.Gestures.Jump);
    }

	public override bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{	
        if(gesture == KinectGestures.Gestures.Jump)
        {
			    jump = true;
        }

        return true;
	}

}
