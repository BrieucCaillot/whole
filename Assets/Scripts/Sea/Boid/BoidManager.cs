using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    const int threadGroupSize = 1024;

    public GameObject redCurrent;
    public GameObject blueCurrent;

    private BoidSettings settings;

    public BoidSettings initalSettings;
    public BoidSettings separationSettings;
    public BoidSettings groupingSettings;
    public BoidSettings speedSettings;

    public ComputeShader compute;
    public Transform[] targets;
    Boid[] boids;

    public static List<Vector3> agentsPositions = new List<Vector3>();

    void Start () {
        settings = initalSettings;

        boids = FindObjectsOfType<Boid> ();
        foreach (Boid b in boids) {
            b.Initialize (settings, targets);
            agentsPositions.Add(Vector3.zero);    
        }

    }

    public void ResetSettings()
    {
        settings = initalSettings;

        UpdateBoidsSettings(settings);
    }

    public void Separation()
    {
        settings = separationSettings;

        UpdateBoidsSettings(settings);
    }

    public void Grouping()
    {
        settings = groupingSettings;

        UpdateBoidsSettings(settings);
    }

    public void ShowRedCurrent() {
        redCurrent.SetActive(true);
    }

    public void ShowBlueCurrent() {
        blueCurrent.SetActive(true);
        redCurrent.SetActive(false);
    }

    public void HideCurrents() {
        redCurrent.SetActive(false);
        blueCurrent.SetActive(false);
        ResetSettings();
    }

    public void SpeedDown() {
        ShowBlueCurrent();
        Grouping();
    }

    public void SpeedUp() {
        ShowRedCurrent();
        settings = speedSettings;
        UpdateBoidsSettings(settings);
    }

    public void UpdateTargetPosition(Vector3 firstUserKinectPosition, Vector3 secondUserKinectPosition, bool isPlayerOneCalibrated, bool isPlayerTwoCalibrated) {
        if(targets[0].gameObject) {
            GameObject firstTarget = targets[0].gameObject;
            if(isPlayerOneCalibrated){
                Vector3 firstTargetPos = firstTarget.transform.position;
                firstTarget.SetActive(true);
                firstTarget.transform.position = new Vector3(firstUserKinectPosition.x * 20, firstTargetPos.y, firstTargetPos.z);
            }else{
                firstTarget.SetActive(false);
            }
        }

        // if(targets[1].gameObject) {
        //     GameObject secondTarget = targets[1].gameObject;

        //     if(isPlayerTwoCalibrated){
        //         Vector3 secondTargetPos = secondTarget.transform.position;
        //         secondTarget.SetActive(true);
        //         secondTarget.transform.position = new Vector3(secondUserKinectPosition.x* 10, secondUserKinectPosition.y* 10, secondTargetPos.z);
        //     }
        //     else {
        //         secondTarget.SetActive(false);
        //     }
        // }

    } 
    
    void UpdateBoidsSettings(BoidSettings settings)
    {
        foreach (Boid b in boids) {
            b.UpdateSettings(settings);
        }
    }

    void Update () {
        if (boids != null) {

            int numBoids = boids.Length;
            var boidData = new BoidData[numBoids];

            for (int i = 0; i < boids.Length; i++) {
                boidData[i].position = boids[i].position;
                boidData[i].direction = boids[i].forward;
                agentsPositions[i] = boids[i].position;
            }

            var boidBuffer = new ComputeBuffer (numBoids, BoidData.Size);
            boidBuffer.SetData (boidData);

            compute.SetBuffer (0, "boids", boidBuffer);
            compute.SetInt ("numBoids", boids.Length);
            compute.SetFloat ("viewRadius", settings.perceptionRadius);
            compute.SetFloat ("avoidRadius", settings.avoidanceRadius);

            int threadGroups = Mathf.CeilToInt (numBoids / (float) threadGroupSize);
            compute.Dispatch (0, threadGroups, 1, 1);

            boidBuffer.GetData (boidData);

            for (int i = 0; i < boids.Length; i++) {
                boids[i].avgFlockHeading = boidData[i].flockHeading;
                boids[i].centreOfFlockmates = boidData[i].flockCentre;
                boids[i].avgAvoidanceHeading = boidData[i].avoidanceHeading;
                boids[i].numPerceivedFlockmates = boidData[i].numFlockmates;

                boids[i].UpdateBoid ();
            }

            boidBuffer.Release ();
        }
        // UpdateTargetPosition(Vector3.zero);
    }

    public struct BoidData {
        public Vector3 position;
        public Vector3 direction;

        public Vector3 flockHeading;
        public Vector3 flockCentre;
        public Vector3 avoidanceHeading;
        public int numFlockmates;

        public static int Size {
            get {
                return sizeof (float) * 3 * 5 + sizeof (int);
            }
        }
    }
}
