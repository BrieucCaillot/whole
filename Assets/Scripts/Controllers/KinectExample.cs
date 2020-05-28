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

        // TOGGLE ANIM V
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PictosPositionsManager.Instance.Position("V");
        }  
        
        // TOGGLE ANIM BAITBALL
        if (Input.GetKeyDown(KeyCode.E))
        {
            PictosPositionsManager.Instance.Position("Baitball");
        }  
        
        // TOGGLE PICTO DISPERSION
        if (Input.GetKeyDown(KeyCode.R))
        {
            PictosPositionsManager.Instance.Position("Dispersion");
        }  
        
        // TOGGLE PICTO PIQUER
        if (Input.GetKeyDown(KeyCode.T))
        {
            PictosPositionsManager.Instance.Position("Piquer");
        }
        
        // TOGGLE PICTO FLY
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PictosPositionsManager.Instance.Position("Voler");
        }   
        
        // SWITCH SCENE EXAMPLE
        // INTRO SCENE
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneController.Instance.Intro();
        } 
        
        // BIRDS SCENE
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneController.Instance.BirdsScene();
        }    
        // BOID SCENE
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneController.Instance.BoidScene();
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
