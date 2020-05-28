using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static UIManager Instance;
    private Canvas Canvas;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Canvas = Instance.GetComponent<Canvas>();
            Canvas.renderMode = RenderMode.ScreenSpaceCamera;
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
}
