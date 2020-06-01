using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPoseGesture : Gestures
{
    private static bool tPose;

    public static bool hasTPose{
        get { return tPose; }
    }

    public override void UserDetected(uint userId, int userIndex) {
		  GameManager.Instance.kinectManager.DetectGesture(userId, KinectGestures.Gestures.Tpose);
    }

	public override bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{	
        if(gesture == KinectGestures.Gestures.Tpose)
        {
			    tPose = true;
        }

        return true;
	}

}
