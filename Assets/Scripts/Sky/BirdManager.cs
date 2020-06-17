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

    private bool needBirdsLookAtPhare = false;
    private bool needBirdsLookAtBoids = false;

    private bool isComplete = false;

    private float birdsSpeed = 0.8f;

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
            int randomPositionNumber = numOfBirds;
            Vector3 randomBirdPosition = new Vector3(Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber));
            allBirds.Add((GameObject) Instantiate(birdPreFab, parentPosition + randomBirdPosition, Quaternion.identity, parent));
        }
    }

    void Update()
    {
        UpdateLookAtBirds();
    }

    private void UpdateLookAtBirds() {
        foreach (GameObject bird in allBirds) {
            if(needBirdsLookAtPhare) {
                bird.transform.LookAt(new Vector3(45.4f, 330.1f, -2.3f));
                bird.transform.eulerAngles = new Vector3(bird.transform.eulerAngles.x, bird.transform.eulerAngles.y - 70, bird.transform.eulerAngles.z - 20);
            } 
            else {
                // bird.transform.eulerAngles = new Vector3(0, 0, Random.Range(-6, 6));
            }
        }
    }

    public void DiveBirds() { 
        parent.gameObject.GetComponent<BezierFollow>().enabled = false;
        needBirdsLookAtPhare = false;

        foreach (GameObject bird in allBirds) {
            bird.transform.DOLocalRotate(new Vector3(bird.transform.eulerAngles.x + 70, bird.transform.eulerAngles.y, bird.transform.eulerAngles.z), 2f);
        }

        Sequence seq = DOTween.Sequence(); 
        seq.Append(parent.DOMove(new Vector3(65, -520, 319), 3f).SetEase(Ease.InQuint));

        DOTween.To(() => RenderSettings.fogColor, x => RenderSettings.fogColor = x, new Color(0.2117f, 0.2470588f, 0.6745098f, 1), 1f).SetDelay(2);
        DOTween.To(() => Camera.main.backgroundColor, x => Camera.main.backgroundColor = x, new Color(0.2117f, 0.2470588f, 0.6745098f, 1), 1f).SetDelay(2);
        seq.OnComplete(() => { 
            GameManager.Instance.BirdSceneCompleted();
            // GameManager.Instance.InteractionCompleteHandler();
            }
        ); 
    }

    
    public void FlyBirdsNormal(Vector3 firstUserKinectPosition, Vector3 secondUserKinectPosition, bool isPlayerOneCalibrated, bool isPlayerTwoCalibrated) {
        Vector3 birdsPosition = parent.transform.position;
        Vector3 birdsRotation = parent.transform.eulerAngles;

        parent.transform.position = new Vector3(birdsPosition.x, birdsPosition.y, birdsPosition.z + birdsSpeed);
        // parent.transform.position = new Vector3(birdsPosition.x + (firstUserKinectPosition.x * 0.5), birdsPosition.y, birdsPosition.z + birdsSpeed);
    }

    public void FlyBirdsFaster() {
        foreach (GameObject bird in allBirds)
        {
            bird.GetComponent<Animator>().Play("SpeedUp", 0, 0.5f);

            int randomPositionNumber = numOfBirds / 4;
            Vector3 randomBirdPosition = new Vector3(Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber));
            bird.transform.DOLocalMove(randomBirdPosition, 6f).SetEase(Ease.InOutCubic);
        }
    }

    public void VPositionBirds() 
    { 
        Debug.Log("VPos");
        Vector3 VBirdPosition = new Vector3(0, 1, 0); 
        int leftV = 0; 
        int rightV = 0;

        for (int i = 0; i < allBirds.Count; i++) {

            allBirds[i].GetComponent<Animator>().Play("Fly", 0, 0f);

            if(i%2==0 && i != 0) {
                leftV++;
                VBirdPosition = new Vector3(leftV * 5, 1, -leftV* 5);
            }
            if(i%2==1) {
                rightV++;
                VBirdPosition = new Vector3(-rightV* 5, 1, -rightV * 5);
            }
            allBirds[i].transform.DOLocalMove(new Vector3(VBirdPosition.x, VBirdPosition.y, VBirdPosition.z), 6f).SetEase(Ease.InOutCubic).OnComplete(() => {
                if(!isComplete) {
                    isComplete = true;
                    // GameManager.Instance.InteractionCompleteHandler();
                    Invoke("GoToCircleRoute", 5f);
                }
            }); 
        }
        
    }

    private void GoToCircleRoute() { 
        // parent.DOMove(new Vector3(parent.transform.position.x, parent.transform.position.y, -500f), 5f).SetEase(Ease.InOutCubic).OnComplete(() => {
            foreach (GameObject bird in allBirds)
            {
                int randomPositionNumber = numOfBirds / 4;
                Vector3 randomBirdPosition = new Vector3(Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber), Random.Range(-randomPositionNumber, randomPositionNumber));
                bird.transform.DOLocalMove(randomBirdPosition, 6f).SetEase(Ease.InOutCubic);
            }
        // });

        parent.DOMove(new Vector3(58.89471f, 296, -150.5997f), 20f).SetEase(Ease.InCubic).OnComplete(() => {
            RotateAroundPhare();
        });
    }
    private void RotateAroundPhare() {
        parent.gameObject.GetComponent<BezierFollow>().enabled = true;
        needBirdsLookAtPhare = true;
    }
}
