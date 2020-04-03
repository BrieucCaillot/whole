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
        transform.position = (ReturnCentroid.FindCentroid(Flock.agents));
        // Debug.Log(ReturnCentroid.FindCentroid(Flock.agents));
    }
}
