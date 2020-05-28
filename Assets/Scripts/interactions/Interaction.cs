using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : ScriptableObject
{
    public bool enable;

    public void OnEnable() {
        enable = true;
    }

    public void Enable() 
    {
        enable = true;
    }

    public void Disable()
    {
        enable = false;
    }

    public bool IsEnabled()
    {
        return enable;
    }

    public virtual bool Listen()
    {
        return false;
    }
}
