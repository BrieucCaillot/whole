using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Target")]
public class GoToTargetBehavior : FlockBehavior
{
    Vector3 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public Vector3 targetPosition = Random.insideUnitSphere * 50;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 targetMove = targetPosition - agent.transform.position;

        //TODO: find out why not working with smoothDamp
        // targetMove = Vector3.SmoothDamp(agent.transform.forward, targetMove, ref currentVelocity, agentSmoothTime);

        return targetMove;
    }
}
