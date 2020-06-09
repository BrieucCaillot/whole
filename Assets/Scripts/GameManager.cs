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
    private BoidManager boidManager;
    private BirdManager birdManager;
    private GameObject birdGameObject;
    private GameObject boidGameObject;

    private bool isPlayerOneCalibrated;
    private bool isPlayerTwoCalibrated;

    public KinectManager kinectManager;
    public UserKinectPosition userKinectPosition;
    public Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("StartScene", UserDetectedHandler);
        actions.Add("test", Test);
    }

    void Test()
    {
        Debug.Log("Interaction test");
    }
    
    void Update()
    {

        isPlayerOneCalibrated = GameManager.Instance.kinectManager.IsPlayerCalibrated(GameManager.Instance.kinectManager.GetPlayer1ID());
        isPlayerTwoCalibrated = GameManager.Instance.kinectManager.IsPlayerCalibrated(GameManager.Instance.kinectManager.GetPlayer2ID());

        // GO = GameObject
        if(!birdGameObject){
            GetBirdsGameObject();
        }
        if(birdManager) {
            birdManager.FlyBirdsNormal(userKinectPosition.getFirstUserVector(), userKinectPosition.getSecondUserVector(), isPlayerOneCalibrated, isPlayerTwoCalibrated);
        }

        if(!boidGameObject) {
            GetBoidsGameObject();
        }
            
        if(boidManager) {
            boidManager.UpdateTargetPosition(userKinectPosition.getFirstUserVector(), userKinectPosition.getSecondUserVector(), isPlayerOneCalibrated, isPlayerTwoCalibrated);
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

    public void BirdSceneCompleted() {
        SceneManager.LoadScene("Boids");
    }

    public void BoidSceneCompleted() {
        // SceneManager.LoadScene("Boids");
    }

    private void GetBirdsGameObject() {
        birdGameObject = GameObject.Find("Birds");
        if(birdGameObject) {
            birdManager = birdGameObject.GetComponent<BirdManager>();
            SetupBirdsScene();
        }
    }

    private void GetBoidsGameObject() {
        boidGameObject = GameObject.Find("Boid Manager");
        if(boidGameObject) {
            boidManager = boidGameObject.GetComponent<BoidManager>();
            SetupBoidsScene();
        }
    }

    

    private void SetupBirdsScene() {
        actions.Add("flyBirdsFaster", birdManager.FlyBirdsFaster);
        actions.Add("vPositionBirds", birdManager.VPositionBirds);
        actions.Add("diveBirds", birdManager.DiveBirds);
    }

    
    private void SetupBoidsScene() {
        // actions.Add("boidSeparation", boidManager.Separation);
    }

    //Generic
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