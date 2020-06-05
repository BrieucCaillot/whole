using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsiGesture : Gestures
{
    private static bool psi;

    public static bool isPsiDone{
        get { return psi; }
    }

    public override void UserDetected(uint userId, int userIndex) {
		  GameManager.Instance.kinectManager.DetectGesture(userId, KinectGestures.Gestures.Psi);
    }

	public override bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{	
        if(gesture == KinectGestures.Gestures.Psi)
        {
			    psi = true;
        }

        return true;
	}

}
