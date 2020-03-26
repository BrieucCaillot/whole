using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    
    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector3 velocity)
    {
        //Portential issue transform.up ? transform.forward ? rotate ?
        transform.Rotate(velocity * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;
    }
}
