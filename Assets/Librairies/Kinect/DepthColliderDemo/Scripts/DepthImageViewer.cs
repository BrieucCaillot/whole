using UnityEngine;
using System.Collections;

public class DepthImageViewer : MonoBehaviour 
{
	// the KinectManager instance
	private KinectManager manager;

    public Camera mainCamera;


	// the foreground texture
	private Texture2D foregroundTex;
	
	// rectangle taken by the foreground texture (in pixels)
	private Rect foregroundRect;
	private Vector2 foregroundOfs;

	// public Vector3 posCollider;

	// game objects to contain the joint colliders
	private GameObject[] jointColliders = null;
	


	void Start () 
	{

		Rect cameraRect = mainCamera.pixelRect;
		float rectHeight = cameraRect.height;
		float rectWidth = cameraRect.width;
		
		if(rectWidth > rectHeight)
			rectWidth = rectHeight * KinectWrapper.Constants.DepthImageWidth / KinectWrapper.Constants.DepthImageHeight;
		else
			rectHeight = rectWidth * KinectWrapper.Constants.DepthImageHeight / KinectWrapper.Constants.DepthImageWidth;

		foregroundOfs = new Vector2((cameraRect.width - rectWidth) / 2, (cameraRect.height - rectHeight) / 2);
		foregroundRect = new Rect(foregroundOfs.x, cameraRect.height - foregroundOfs.y, rectWidth, -rectHeight);
		
		// calculate the foreground rectangle
		// Rect cameraRect = Camera.main.pixelRect;
		// float rectHeight = cameraRect.height;
		// float rectWidth = cameraRect.width;
		
		// if(rectWidth > rectHeight)
		// 	rectWidth = rectHeight * KinectWrapper.Constants.DepthImageWidth / KinectWrapper.Constants.DepthImageHeight;
		// else
		// 	rectHeight = rectWidth * KinectWrapper.Constants.DepthImageHeight / KinectWrapper.Constants.DepthImageWidth;

		// foregroundOfs = new Vector2((cameraRect.width - rectWidth) / 2, (cameraRect.height - rectHeight) / 2);
		// foregroundRect = new Rect(foregroundOfs.x, cameraRect.height - foregroundOfs.y, rectWidth, -rectHeight);
		
		// // create joint colliders
		// int numColliders = (int)KinectWrapper.NuiSkeletonPositionIndex.Count;
		// jointColliders = new GameObject[numColliders];
		
		// for(int i = 0; i < numColliders; i++)
		// {
		// 	string sColObjectName = ((KinectWrapper.NuiSkeletonPositionIndex)i).ToString();
		// 	jointColliders[i] = new GameObject(sColObjectName);
		// 	jointColliders[i].transform.parent = transform;

		// 	// SphereCollider collider = jointColliders[i].AddComponent<SphereCollider>();
		// 	// collider.radius = 1f;
		// }
	}
	
	void Update () 
	{
		if(manager == null)
		{
			manager = KinectManager.Instance;
		}

		// get the users texture
		if(manager && manager.IsInitialized())
		{
			foregroundTex = manager.GetUsersLblTex();
		}

		// if(manager.IsUserDetected())
		// {
		// 	uint userId = manager.GetPlayer1ID();

		// 	// update colliders
		// 	int numColliders = (int)KinectWrapper.NuiSkeletonPositionIndex.Count;
			
		// 	// Debug.Log(manager.GetRawSkeletonJointPos(userId, 1));
		// 	// for(int i = 0; i < numColliders; i++)
		// 	// {
		// 		if(manager.IsJointTracked(userId, 1))
		// 		{
		// 			Vector3 posJoint = manager.GetRawSkeletonJointPos(userId, 1);
		// 			if(posJoint != Vector3.zero)
		// 			{
		// 				// convert the joint 3d position to depth 2d coordinates
		// 				Vector2 posDepth = manager.GetDepthMapPosForJointPos(posJoint);
						
		// 				float scaledX = posDepth.x * foregroundRect.width / KinectWrapper.Constants.DepthImageWidth;
		// 				float scaledY = posDepth.y * -foregroundRect.height / KinectWrapper.Constants.DepthImageHeight;

		// 				float screenX = foregroundOfs.x + scaledX;
		// 				float screenY = Camera.main.pixelHeight - (foregroundOfs.y + scaledY);
		// 				float zDistance = posJoint.z - Camera.main.transform.position.z;
						
		// 				Vector3 posScreen = new Vector3(screenX, screenY, zDistance);
		// 				Vector3 posCollider = Camera.main.ScreenToWorldPoint(posScreen);
		// 					// Debug.Log(GameObject.Find("Head"));
		// 				// InteractionManager.Instance.UpdateUserKinectPosition(posCollider);
		// 				// jointColliders[i].transform.position = posCollider;
		// 			}
		// 		}
		// 	// }
		// }

	}

	void OnGUI()
	{
		if(foregroundTex)
		{
			GUI.DrawTexture(foregroundRect, foregroundTex);
		}
	}

    public Vector3 getUserVector() {
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
}
