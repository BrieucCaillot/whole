using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    
    void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
