using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Flock/Behavior/StayInRadius")]
public class StayInRadiusBehavior : FlockBehavior
{
    public Vector3 center;
    public float radius = 100;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 move = Vector3.zero;
        Vector3 centerOffset = center - agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9f)
        {
            move = Vector3.zero;
        }
        else
        {
            move = centerOffset * t * t;
        }

        return move;
    }
}
