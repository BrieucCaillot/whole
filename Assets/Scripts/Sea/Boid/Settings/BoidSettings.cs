using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoidSettings : ScriptableObject {
    // Settings
    public float minSpeed = 5f;
    public float maxSpeed = 8f;
    public float perceptionRadius = 2.5f;
    public float avoidanceRadius = 1f;
    public float maxSteerForce = 8f;

    public float alignWeight = 2f;
    public float cohesionWeight = 1f;
    public float seperateWeight = 2.5f;

    public float targetWeight = 2f;

    [Header ("Collisions")]
    public LayerMask obstacleMask;
    public float boundsRadius = .27f;
    public float avoidCollisionWeight = 20f;
    public float collisionAvoidDst = 5f;
}
