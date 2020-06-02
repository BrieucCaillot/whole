using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCameraPosition : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FindCentroid(BoidManager.agentsPositions);
    }

    Vector3 FindCentroid ( List<Vector3> agentsPositions ) {
 
         Vector3 centroid;
         Vector3 minPoint = agentsPositions[0];
         Vector3 maxPoint = agentsPositions[0];
 
         for ( int i = 1; i < agentsPositions.Count; i ++ ) {
             Vector3 pos = agentsPositions[i];
             if( pos.x < minPoint.x )
                 minPoint.x = pos.x;
             if( pos.x > maxPoint.x )
                 maxPoint.x = pos.x;
             if( pos.y < minPoint.y )
                 minPoint.y = pos.y;
             if( pos.y > maxPoint.y )
                 maxPoint.y = pos.y;
             if( pos.z < minPoint.z )
                 minPoint.z = pos.z;
             if( pos.z > maxPoint.z )
                 maxPoint.z = pos.z;
         }
 
         centroid = minPoint + 0.5f * ( maxPoint - minPoint );
 
         return centroid;

     }
}
