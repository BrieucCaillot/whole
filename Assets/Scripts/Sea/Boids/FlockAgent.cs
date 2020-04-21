using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    
    //maybe dont use colliders for performances issues
    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    Vector3 agentPosition;
    public Vector3 AgentPosition { get { return agentPosition; } }

    Transform agentTransform;
    public Transform AgentTransform { get { return agentTransform; } }

    void Start()
    {
        agentTransform = transform;
        agentPosition = transform.position;
        agentCollider = GetComponent<Collider>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector3 velocity)
    {
        //Portential issue transform.up ? transform.forward ? rotate ?
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}