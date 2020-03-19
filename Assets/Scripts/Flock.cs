using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float rotationSpeed = 4f;
    Vector3 averageHeading; 
    Vector3 averagePosition;

    Vector3 direction;
    bool needToTurn = false;

    private float neighbourDistance = 3.0f; 

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        BoxLimits();
    }

    void BoxLimits() {
        if (Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.BoxSize)
        {
            needToTurn = true;
        }
        else {
            needToTurn = false;
        }
        if(needToTurn) 
        {
            direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            speed = Random.Range(0.5f, 1f);
        }
        else {
            if(Random.Range(0, 5) < 1) {
                ApplyFlockRules();
            }
        }
        transform.Translate(0, 0, Time.deltaTime * speed);

    }
    void ApplyFlockRules() {
        GameObject[] allFishsArray;
        allFishsArray = GlobalFlock.allFishs;

        Vector3 vCentre = Vector3.zero;
        Vector3 vAvoid = Vector3.zero;
        Vector3 goalPosition = GlobalFlock.goalPosition;

        float groupSpeed = 1.0f;
        float distance;
        
        int groupSize = 0;

        foreach (GameObject singleFish in allFishsArray)
        {   
            if(singleFish != this.gameObject) 
            {
                distance = Vector3.Distance(singleFish.transform.position, this.transform.position);
                if( distance <= neighbourDistance) {
                    vCentre += singleFish.transform.position;
                    groupSize++;
                    if(distance < 1.0f) 
                    {
                        vAvoid = vAvoid + (this.transform.position - singleFish.transform.position);
                    }
                    Flock anotherFlock = singleFish.GetComponent<Flock>();
                    groupSpeed = groupSpeed + anotherFlock.speed;
                }
            }
        }
        if( groupSize > 0)
        {
            vCentre = vCentre / groupSize + (goalPosition - this.transform.position);
            speed = groupSpeed / groupSize;

            Vector3 direction = (vCentre + vAvoid) - transform.position;
            if(direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            }
        }
        
    }
}
