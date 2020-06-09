using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserKinectPosition : MonoBehaviour
{
	private Rect foregroundRect;
	private Vector2 foregroundOfs;

	private Texture2D foregroundTex;

    
    public Camera mainCamera;
    void Start() {
        Rect cameraRect = mainCamera.pixelRect;
		float rectHeight = cameraRect.height;
		float rectWidth = cameraRect.width;
		
		if(rectWidth > rectHeight)
			rectWidth = rectHeight * KinectWrapper.Constants.DepthImageWidth / KinectWrapper.Constants.DepthImageHeight;
		else
			rectHeight = rectWidth * KinectWrapper.Constants.DepthImageHeight / KinectWrapper.Constants.DepthImageWidth;

		foregroundOfs = new Vector2((cameraRect.width - rectWidth) / 2, (cameraRect.height - rectHeight) / 2);
		foregroundRect = new Rect(foregroundOfs.x, cameraRect.height - foregroundOfs.y, rectWidth, -rectHeight);
		
    }
    public Vector3 getFirstUserVector() {
        uint userId = GameManager.Instance.kinectManager.GetPlayer1ID();
            
        if(GameManager.Instance.kinectManager.IsJointTracked(userId, 1))
        {
            Vector3 posJoint = GameManager.Instance.kinectManager.GetRawSkeletonJointPos(userId, 1);
            if(posJoint != Vector3.zero)
            {
                Vector2 posDepth = GameManager.Instance.kinectManager.GetDepthMapPosForJointPos(posJoint);
                
                float scaledX = posDepth.x * foregroundRect.width / KinectWrapper.Constants.DepthImageWidth;
                float scaledY = posDepth.y * -foregroundRect.height / KinectWrapper.Constants.DepthImageHeight;

                float screenX = foregroundOfs.x + scaledX;
                float screenY = mainCamera.pixelHeight - (foregroundOfs.y + scaledY);
                float zDistance = posJoint.z - mainCamera.transform.position.z;
                
                Vector3 posScreen = new Vector3(screenX, screenY, zDistance);
                Vector3 posCollider = mainCamera.ScreenToWorldPoint(posScreen);
                return posCollider;
            }
        }
            return Vector3.zero;
    }

        public Vector3 getSecondUserVector() {
        uint userId = GameManager.Instance.kinectManager.GetPlayer2ID();
            
        if(GameManager.Instance.kinectManager.IsJointTracked(userId, 1))
        {
            Vector3 posJoint = GameManager.Instance.kinectManager.GetRawSkeletonJointPos(userId, 1);
            if(posJoint != Vector3.zero)
            {
                Vector2 posDepth = GameManager.Instance.kinectManager.GetDepthMapPosForJointPos(posJoint);
                
                float scaledX = posDepth.x * foregroundRect.width / KinectWrapper.Constants.DepthImageWidth;
                float scaledY = posDepth.y * -foregroundRect.height / KinectWrapper.Constants.DepthImageHeight;

                float screenX = foregroundOfs.x + scaledX;
                float screenY = mainCamera.pixelHeight - (foregroundOfs.y + scaledY);
                float zDistance = posJoint.z - mainCamera.transform.position.z;
                
                Vector3 posScreen = new Vector3(screenX, screenY, zDistance);
                Vector3 posCollider = mainCamera.ScreenToWorldPoint(posScreen);
                return posCollider;
            }
        }
            return Vector3.zero;
    }
    void OnGUI()
	{
		if(foregroundTex)
		{
			GUI.DrawTexture(foregroundRect, foregroundTex);
		}
	}
}
