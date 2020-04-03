using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredAvoidance")]
public class SteeredAvoidanceBehavior : FilterFlockBehavior
{
    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neigbors, return no adjustment
        if (context.Count == 0) {
            return Vector3.zero;   
        }

        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;

        foreach (Transform item in context)
        {
            if (Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius) {
                nAvoid++;
                avoidanceMove += agent.transform.position - item.position;
            }
        }

        if (nAvoid > 0) {
            avoidanceMove /= nAvoid;
        }

        avoidanceMove = Vector3.SmoothDamp(agent.transform.forward, avoidanceMove, ref currentVelocity, agentSmoothTime);

        return avoidanceMove;
    }
}
