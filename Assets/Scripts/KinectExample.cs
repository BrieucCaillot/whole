using UnityEngine;

public class KinectExample : Singleton<KinectExample>
{
    // Update is called once per frame
    void Update()
    {
        // EVERYONE IS DETECTED
        if (Input.GetKeyDown(KeyCode.A))
        {
            IntroManager.Hide();
            SceneController.BirdsScene();
        }
        
        // BOID SCENE
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneController.BoidScene();
        }
        
        // NEW INTERACTION
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.NewInteraction();
        }

        // TOGGLE ANIM V
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PictosPositionsManager.Position("V");
        }  
        
        // TOGGLE ANIM BAITBALL
        if (Input.GetKeyDown(KeyCode.E))
        {
            PictosPositionsManager.Position("Baitball");
        }  
        
        // TOGGLE PICTO DISPERSION
        if (Input.GetKeyDown(KeyCode.R))
        {
            PictosPositionsManager.Position("Dispersion");
        }  
        
        // TOGGLE PICTO PIQUER
        if (Input.GetKeyDown(KeyCode.T))
        {
            PictosPositionsManager.Position("Piquer");
        }
        
        // TOGGLE PICTO FLY
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PictosPositionsManager.Position("Voler");
        }
    }
}
