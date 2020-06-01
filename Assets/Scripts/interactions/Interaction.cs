using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Interaction : MonoBehaviour
{
    public bool enable;
    public string action;
	
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

    public virtual string GetAction(){
        return action;
    }

    public virtual string GetInfo() {
        return "";
    }
}
