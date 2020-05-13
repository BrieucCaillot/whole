using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusAnimation : MonoBehaviour
{
    public Vector3 bounds = new Vector3(15, 10, 5);
    public bool enable = false;
    public int offsetTop = 60;

    Vector3 velocity = new Vector3(0, 0, 0);
    

    // Update is called once per frame
    void Update()
    {
        if (enable == true) {
            velocity.x = Mathf.Sin(Time.time) * bounds.x;
            velocity.y = offsetTop + Mathf.Sin(Time.time) * bounds.y;
            velocity.z = Mathf.Sin(Time.time) * bounds.z;

            transform.position = velocity;
        }
    }
}
