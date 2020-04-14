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
        if(Input.GetKeyDown("space")) {
            needVPosition = true;
        }

        if(needVPosition == true) {
            VBirdPosition();
        }
            UpdateSinWaveMovement();

    }

    void UpdateSinWaveMovement() 
    {
            foreach (GameObject bird in allBirds)
            {
                float speedBird = Random.Range(-0.4f, 0.4f);
                float velocity = ReturnSinSpeed.sinSpeed(Time.time - bias, speedBird * amplitude, frequency, 0);

                // bird.transform.LookAt(CenterMountain.transform.position);
                bird.transform.position = new Vector3(bird.transform.position.x + velocity, bird.transform.position.y + velocity * 6, bird.transform.position.z + velocity);
                bird.transform.eulerAngles = new Vector3(bird.transform.eulerAngles.x + (velocity * 500), bird.transform.eulerAngles.y, bird.transform.eulerAngles.z);

            }
    }

    void VBirdPosition() {
        Vector3 VBirdPosition = new Vector3(0, 1, 0);
        int leftV = 0;
        int rightV = 0;
        
        for (int i = 0; i < numOfBirds; i++) {
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

    
}
