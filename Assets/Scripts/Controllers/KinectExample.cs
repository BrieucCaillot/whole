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
        
        // EVERYONE IS DETECTED
        if (Input.GetKeyDown(KeyCode.A))
        {
            IntroManager.Instance.Hide();
        }
        
        // SWITCH EXAMPLE
        // BIRDS SCENE
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneController.Instance.BirdsScene();
        }    
        // BOID SCENE
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneController.Instance.BoidScene();
        }    
        
        // DISPLAY LOADER
        if (Input.GetKeyDown(KeyCode.R))
        {
            PictoLoadingManager.Instance.LoaderInit();
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
