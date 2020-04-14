using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpeed : MonoBehaviour
{
    public static float getSpeed() {
        float birdsSpeed = Random.Range(-3f, 3f);
        // Debug.Log(birdsSpeed);
        return birdsSpeed;
    }
}