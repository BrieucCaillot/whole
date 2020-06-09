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
        SetupActions();
    }
    
    void SetupActions()
    {
        actions.Add("StartScene", UserDetectedHandler);
        actions.Add("test", Test);
    }

    void SetupBirdsActions()
    {
        actions.Add("flyBirdsFaster", birdManager.flyBirdsFaster);
        actions.Add("vPositionBirds", birdManager.vPositionBirds);
        actions.Add("diveBirds", birdManager.diveBirds);
    }

    void SetupBoidsActions()
    {
        // actions.Add("boidActionTest", boidManager.boidActionTest);
    }

    void Test()
    {
        Debug.Log("Interaction test");
    }

    private void GetBirdsComponent() {
        birdGameObject = GameObject.Find("Birds");
        
        if (birdGameObject) {
            birdManager = birdGameObject.GetComponent<BirdManager>();
            SetupBirdsActions();
        }
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

    //handlers
    void UserDetectedHandler()
    {
        introManager.Hide();
    }

    public void introSceneCompleted() {
        SceneManager.LoadScene("Birds");
        InteractionCompleteHandler();
    }

    public void InteractionHandler(Interaction interaction)
    {
        actions[interaction.GetAction()]();
    }
    
    public void InteractionCompleteHandler()
    {
        int currentIndex = interactionManager.GetIndex();
        interactionManager.SetIndex(currentIndex + 1);
    }
}