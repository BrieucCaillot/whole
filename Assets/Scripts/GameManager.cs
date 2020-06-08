using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    public int index = 0;

    //managers
    public InteractionManager interactionManager;
    public IntroManager introManager;

    //behaviors
    private BirdManager birdManager;
    private GameObject birdGameObject;
    private BoidManager boidManager;
    public KinectManager kinectManager;
    public UserKinectPosition userKinectPosition;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("StartScene", UserDetectedHandler);
    }
    
    void Update()
    {
        if(!birdGameObject){
            GetBirdsComponent();
        }
        if(birdManager) {
            birdManager.flyBirdsNormal(userKinectPosition.getUserVector());
        }
    }

    void UserDetectedHandler()
    {
        introManager.Hide();
    }

    public void introSceneCompleted() {
        SceneManager.LoadScene("Birds");
        InteractionCompleteHandler();
    }
    
    private void GetBirdsComponent() {
        birdGameObject = GameObject.Find("Birds");
        if (birdGameObject) {
            birdManager = birdGameObject.GetComponent<BirdManager>();
            SetupBirdsScene();
        }
    }

    private void SetupBirdsScene() {
        actions.Add("flyBirdsFaster", birdManager.flyBirdsFaster);
        actions.Add("vPositionBirds", birdManager.vPositionBirds);
        actions.Add("diveBirds", birdManager.diveBirds);
    }

    public void InteractionHandler(Interaction interaction)
    {
        actions[interaction.GetAction()]();
        // Debug.Log("Warning: No action named " + interaction.GetAction());
    }
    
    public void InteractionCompleteHandler()
    {
        int currentIndex = interactionManager.GetIndex();
        interactionManager.SetIndex(currentIndex + 1);
    }
}