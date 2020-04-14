using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/SteeredAlignment")]
public class SteeredAlignmentBehavior : FilterFlockBehavior
{
    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neigbors, maintain current alignment
        if (context.Count == 0) {
            return agent.transform.forward;   
        }

        Vector3 alignmentMove = Vector3.zero;

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += item.transform.forward;
        }

        alignmentMove /= context.Count;
        
        alignmentMove = Vector3.SmoothDamp(agent.transform.forward, alignmentMove, ref currentVelocity, agentSmoothTime);

        return alignmentMove;
    }
}
