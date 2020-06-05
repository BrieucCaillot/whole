using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatGesture : Gestures
{
    private static bool squat;

    public static bool isSquatDone{
        get { return squat; }
    }

    public override void UserDetected(uint userId, int userIndex) {
		  GameManager.Instance.kinectManager.DetectGesture(userId, KinectGestures.Gestures.Squat);
    }

	public override bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{	
        if(gesture == KinectGestures.Gestures.Squat)
        {
			    squat = true;
        }

        return true;
	}

}
