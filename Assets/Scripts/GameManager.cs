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
    public VoiceoverManager voiceoverManager;
    public SubtitleManager subtitleManager;
    public IntroManager introManager;

    //behaviors
    private BirdManager birdManager;
    private GameObject birdGO;
    private BoidManager boidManager;
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
        Debug.Log("Space bar pressed");
    }
    
    void Update()
    {
        if(!birdGO){
            GetBirdsComponent();
        }
        if(birdManager) {
            birdManager.flyBirdsNormal(userKinectPosition.getUserVector());
        }

        // Debug.Log(kinectManager.GetUserOrientation(1, false));
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
        birdGO = GameObject.Find("Birds");
        if(birdGO) {
            birdManager = birdGO.GetComponent<BirdManager>();
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
    }
    
    public void InteractionCompleteHandler()
    {
        int currentIndex = interactionManager.GetIndex();
        interactionManager.SetIndex(currentIndex + 1);
    }


    // public static void NewInteraction()
    // {
    //     if (!VoiceoverManager.Instance.IsPlaying() && !SubtitleManager.Instance.IsActive())
    //     {
    //         InteractionNumber++;
    //         VoiceoverManager.Instance.PlayVoiceover();
    //         SubtitleManager.Instance.GetSubtitles();
    //     }
    // }
}