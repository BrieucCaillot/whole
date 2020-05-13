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
<<<<<<< HEAD
        transform.position = (ReturnCentroid.FindCentroid(BoidManager.agentsPositions));
=======
        transform.position = (ReturnCentroid.FindCentroid(Flock.agents));
>>>>>>> e35621fe45827db6de541fb73925d1dba7db8e2f
        // Debug.Log(ReturnCentroid.FindCentroid(Flock.agents));
    }
}
