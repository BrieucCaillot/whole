using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectExample : MonoBehaviour
{
    public static KinectExample Instance;
    
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
    
    // Update is called once per frame
    void Update()
    {
        // SWITCH EXAMPLE
        // BIRDS SCENE
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneController.Instance.BirdsScene();
        }    
        // BOID SCENE
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneController.Instance.BoidScene();
        }    
        // INTRO SCENE
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneController.Instance.Intro();
        }  
        
        // NEW INTERACTION
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (!VoiceoverManager.Instance.GetActive() && !SubtitleManager.Instance.GetActive())
            {
                GameManager.Instance.InteractionNumber++;
                VoiceoverManager.Instance.PlayVoiceover();
                SubtitleManager.Instance.GetSubtitles();
            }
        }
        
    }
}
