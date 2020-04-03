using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public FlockAgent agentPrefab;
    public static List<FlockAgent> agents = new List<FlockAgent>();

    public FlockBehavior behavior;

    [Range(10, 500)]
    public int startingCount = 200;
    // const float AgentDensity = 0.5f;

    [Range(1.0f, 100.0f)]
    public float driveFactor = 15.0f;

    [Range(1.0f, 100.0f)]
    public float maxSpeed = 10.0f;

    [Range(1.0f, 50.0f)]
    public float neighborRadius = 10.0f;

    [Range(0.0f, 5.0f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;

    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        //TODO: Find which one is best ?
        // squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        squareAvoidanceRadius = squareNeighborRadius * squareNeighborRadius * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * 50,
                Quaternion.identity,
                transform
            );

            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    void Update()
    {

        foreach (FlockAgent agent in agents)
        {        
            List<Transform> context = GetNearbyObjects(agent);
            Vector3 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);

        foreach (Collider collider in contextColliders)
        {
            if (collider != agent.AgentCollider)
            {
                context.Add(collider.transform);
            }
        }

        return context;
    } 
}
