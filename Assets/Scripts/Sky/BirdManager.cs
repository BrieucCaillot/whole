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
        flyBirdsNormal(Vector3.zero);
        // DetectInteractions();
        // UpdateSinWaveMovement();
    }

    public void vPositionBirds() 
    { 
        Debug.Log("vBirds");
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
            // allBirds[i].transform.DOMove(allBirds[i].transform.position + VBirdPosition, 5f).SetEase(Ease.InOutCubic).OnComplete(() => GameManager.Instance.InteractionCompleteHandler()); 
        }
        
    }

    public void diveBirds() {
        Debug.Log("dive");
        GameManager.Instance.InteractionCompleteHandler();

    }

    public void flyBirdsFaster() {
        Debug.Log("fly");
        birdsSpeed = 1.5f;
        GameManager.Instance.InteractionCompleteHandler();
    }

    public void flyBirdsNormal(Vector3 userKinectPosition) {
        Vector3 birdsPosition = parent.transform.position;
        Vector3 birdsRotation = parent.transform.eulerAngles;

        parent.transform.position = new Vector3(birdsPosition.x + (userKinectPosition.x * 2), birdsPosition.y, birdsPosition.z);
        if(parent.transform.rotation.z < 0.45f && parent.transform.rotation.z > -0.45f) {
            return;
        }
        parent.transform.eulerAngles  = new Vector3(birdsRotation.x, birdsRotation.y, birdsRotation.z + (-userKinectPosition.x * 4));
    }
}
