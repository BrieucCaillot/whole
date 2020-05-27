using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


// public int progress = 0;

public class InteractionManager : Singleton<InteractionManager>
{
    public bool isVPositionComplete = false;
    [SerializeField] private CinemachineVirtualCamera[] CinemachineCameras;
    [SerializeField] private Camera MainCamera;

    public static GameObject boidsTarget;

    public int cameraIndex = 0;
    private float speed = 0;

    public void normalFly(List<GameObject> allBirds, Transform parent) {
        parent.position = new Vector3(parent.position.x, parent.position.y, parent.position.z + 0.5f);
        foreach (GameObject bird in allBirds) {
            bird.transform.LookAt(new Vector3(100, 100, 100));
        }

    }

    public void setVPosition(List<GameObject> allBirds, Transform parent) {
        if(isVPositionComplete) return;
        Vector3 VBirdPosition = new Vector3(0, 1, 0);
        int leftV = 0;
        int rightV = 0;
        
        for (int i = 0; i < allBirds.Count; i++) {
            if(i%2==0 && i != 0) {
                leftV++;
                VBirdPosition = new Vector3(leftV, 1, -leftV);
            }
            if(i%2==1) {
                rightV++;
                VBirdPosition = new Vector3(rightV, 1, rightV);
            }

            allBirds[i].transform.position = Vector3.Slerp(allBirds[i].transform.position, parent.transform.position + VBirdPosition, 0.02f);
        }
        
    }


    public void DiveBird(Transform parent) {
        Sequence seq = DOTween.Sequence();
            seq.Append(parent.DOMove(parent.position + new Vector3(0, 2f, 0), 0.4f).SetEase(Ease.InOutCubic));
            seq.Append(parent.DOMove(new Vector3(65, -320, 319), 1f).SetEase(Ease.InQuint));

            seq.PrependInterval(1);
            
            DOTween.To(() => RenderSettings.fogColor, x => RenderSettings.fogColor = x, Color.blue, 1f);
            DOTween.To(() => MainCamera.backgroundColor, x => MainCamera.backgroundColor = x, Color.blue, 1f);

            seq.OnComplete(()=>
            {
                StartCoroutine(LoadAsyncScene.Instance.SceneLoader());
            });

        cameraIndex = 1;
        CameraHandler(cameraIndex);
    }

    public void CameraHandler(int cameraIndex) {
        CinemachineCameras[cameraIndex].Priority = 10;
    }

    public void UpdateUserKinectPosition(Vector3 position) {
        if(!boidsTarget){
            boidsTarget = GameObject.Find("Boids/Target");
        }
        
        boidsTarget.transform.position = position;
    }
}
