using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    

    Vector3 agentPosition;
    public Vector3 AgentPosition { get { return agentPosition; } }

    Transform agentTransform;
    public Transform AgentTransform { get { return agentTransform; } }

    void Start()
    {
        agentTransform = transform;
        agentPosition = transform.position;
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}