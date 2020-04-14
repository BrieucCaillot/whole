using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReturnSinSpeed
{
    public static float sinSpeed(float t, float amplitude, float frequency, float x)
    {
        float omega = ((Mathf.PI * 2) / frequency);
        float current = amplitude * omega * Mathf.Sin(omega * (t + x));
        return current;
    }
}