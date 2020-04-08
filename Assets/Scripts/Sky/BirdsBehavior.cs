using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsBehavior : MonoBehaviour
{
    private Transform parent;
    [SerializeField] private GameObject birdPreFab;
    [SerializeField] private int numOfBirds = 5;
    [SerializeField] private GameObject CenterMountain;

    private List<GameObject> allBirds = new List<GameObject>();
    void Start()
    {
        parent = transform;
        Vector3 parentPosition = parent.transform.position;
        
        for (int i = 0; i < numOfBirds; i++)
        {
            Vector3 randomBirdPosition = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
           allBirds.Add((GameObject) Instantiate(birdPreFab, parent.transform.position + randomBirdPosition, Quaternion.identity, parent));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allBirds.Count; i++)
        {
            // allBirds[i].transform.position = Vector3.Slerp(parent.transform.position + randomBirdPosition);
            allBirds[i].transform.LookAt(CenterMountain.transform.position);
        }
    }
}
