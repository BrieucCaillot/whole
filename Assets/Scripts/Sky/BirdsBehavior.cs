using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsBehavior : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private GameObject birdPreFab;
    [SerializeField] private int numOfBirds = 7;
    [SerializeField] private GameObject CenterMountain;
    private List<GameObject> allBirds = new List<GameObject>();

    // SinWave
    private float bias = 0;
    public float frequency = 1;
    public float amplitude = 0.01f;
    public float min = -10000;
    bool needVPosition = false;
    bool needDive = false;
    bool needToFly = true;

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
            Vector3 randomBirdPosition = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
            allBirds.Add((GameObject) Instantiate(birdPreFab, parentPosition + randomBirdPosition, Quaternion.identity, parent));
        }
    }

    void Update()
    {
        // DetectInteractions();
        // UpdateSinWaveMovement();
    }

    public void vPositionBirds() {
        Debug.Log("VPOSWORKING");
        GameManager.Instance.InteractionCompleteHandler();
    }

    public void diveBirds() {
        Debug.Log("dive");
        GameManager.Instance.InteractionCompleteHandler();

    }

    public void flyBirds() {
        Debug.Log("fly");
        GameManager.Instance.InteractionCompleteHandler();
    }
}
