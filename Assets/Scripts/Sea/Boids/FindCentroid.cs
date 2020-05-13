using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReturnCentroid
{
<<<<<<< HEAD
    public static Vector3 FindCentroid ( List<Vector3> targets ) {
 
         Vector3 centroid;
         
         Vector3 minPoint = targets[0];
         Vector3 maxPoint = targets[0];
 
         for ( int i = 1; i < targets.Count; i ++ ) {
             Vector3 pos = targets[ i ];
=======
    public static Vector3 FindCentroid ( List< FlockAgent > targets ) {
 
         Vector3 centroid;
         Vector3 minPoint = targets[ 0 ].transform.position;
         Vector3 maxPoint = targets[ 0 ].transform.position;
 
         for ( int i = 1; i < targets.Count; i ++ ) {
             Vector3 pos = targets[ i ].transform.position;
>>>>>>> e35621fe45827db6de541fb73925d1dba7db8e2f
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
