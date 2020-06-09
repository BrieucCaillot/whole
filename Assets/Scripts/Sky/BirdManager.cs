using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdManager : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private GameObject birdPreFab;
    [SerializeField] private int numOfBirds;
    [SerializeField] private GameObject CenterMountain;
    private List<GameObject> allBirds = new List<GameObject>();

    // SinWave
    private float bias = 0;
    public float frequency = 1;
    public float amplitude = 0.01f;
    public float min = -10000;

    private bool isComplete = false;

    private float birdsSpeed = 0.5f;

    void Start()
    {
        parent = transform;
        Vector3 parentPosition = parent.transform.position;
        InstantiateBirds(parent, parentPosition);
    }

    void InstantiateBirds(Transform parent, Vector3 parentPosition) 
    {
        for (int i = 0; i < numOfBirds; i++)
        {
            int randomPositionNumber = numOfBirds / 4;
            Vector3 randomBirdPosition = new Vector3(Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber));
            allBirds.Add((GameObject) Instantiate(birdPreFab, parentPosition + randomBirdPosition, Quaternion.identity, parent));
        }
    }

    void Update()
    {
        // FlyBirdsNormal(Vector3.zero);
        // DetectInteractions();
        // UpdateSinWaveMovement();
    }

    public void VPositionBirds() 
    { 
        Debug.Log("VPos");
        Vector3 VBirdPosition = new Vector3(0, 1, 0); 
        int leftV = 0; 
        int rightV = 0;

        for (int i = 0; i < allBirds.Count; i++) {
            if(i%2==0 && i != 0) {
                leftV++;
                VBirdPosition = new Vector3(leftV * 10, 1, -leftV* 10);
            }
            if(i%2==1) {
                rightV++;
                VBirdPosition = new Vector3(-rightV* 10, 1, -rightV * 10);
            }
            allBirds[i].transform.DOMove(allBirds[i].transform.position + VBirdPosition, 3f).SetEase(Ease.InOutCubic).OnComplete(() => {
                if(!isComplete) {
                    isComplete = true;
                    GameManager.Instance.InteractionCompleteHandler();
                    GoToCircleRoute();
                }
            }); 
        }
        
    }

    private void GoToCircleRoute() {
        parent.DOMove(new Vector3(58.89471f, 296, -150.5997f), 20f).SetEase(Ease.InOutCubic).OnComplete(() => {
            SetCircleRouteActive();
        });
    }
    private void SetCircleRouteActive() {
            parent.gameObject.GetComponent<BezierFollow>().enabled = true;
            foreach (GameObject bird in allBirds)
            {
                int randomPositionNumber = numOfBirds / 4;
                Vector3 randomBirdPosition = new Vector3(Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber));
                bird.transform.DOMove(randomBirdPosition, 1f).SetEase(Ease.InOutCubic);
            }

    }
    public void DiveBirds() { 
        Debug.Log("Dive");
        parent.gameObject.GetComponent<BezierFollow>().enabled = false;

        Sequence seq = DOTween.Sequence(); 
        seq.Append(parent.DOMove(parent.position + new Vector3(0, 2f, 0), 0.4f).SetEase(Ease.InOutCubic)); 
        seq.Append(parent.DOMove(new Vector3(65, -320, 319), 1f).SetEase(Ease.InQuint));

        seq.PrependInterval(1);

    // DOTween.To(() => RenderSettings.fogColor, x => RenderSettings.fogColor = x, Color.blue, 1f);
    // DOTween.To(() => MainCamera.backgroundColor, x => MainCamera.backgroundColor = x, Color.blue, 1f);
        seq.OnComplete(() => { 
            GameManager.Instance.BirdSceneCompleted();
            GameManager.Instance.InteractionCompleteHandler();
            }
        ); 
    }

    public void FlyBirdsFaster() {
        Debug.Log("FlyFaster");

        birdsSpeed = 1.5f;
        GameManager.Instance.InteractionCompleteHandler();
    }

    public void FlyBirdsNormal(Vector3 firstUserKinectPosition, Vector3 secondUserKinectPosition, bool isPlayerOneCalibrated, bool isPlayerTwoCalibrated) {
        Vector3 birdsPosition = parent.transform.position;
        Vector3 birdsRotation = parent.transform.eulerAngles;

        parent.transform.position = new Vector3(birdsPosition.x, birdsPosition.y, birdsPosition.z + birdsSpeed);
        // parent.transform.position = new Vector3(birdsPosition.x + (userKinectPosition.x * 2), birdsPosition.y, birdsPosition.z + birdsSpeed);
        // if(userKinectPosition.x > 0.5) {
        //     parent.transform.DORotate(new Vector3(0, 0, -35), 0.4f).SetEase(Ease.InOutCubic);
        // }
        // else if(userKinectPosition.x < -0.5) {
        //     parent.transform.DORotate(new Vector3(0, 0, 35), 0.4f).SetEase(Ease.InOutCubic);
        // }
    }
}
