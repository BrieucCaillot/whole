using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    // Start is called before the first frame update
    public static int numFish = 300;
    public static float BoxSize = 10f;
    private Vector3 position;
    [SerializeField] private GameObject fishPreFab;
    public static Vector3 goalPosition = Vector3.zero;

    
    public static GameObject[] allFishs = new GameObject[numFish];
    void Start()
    {
        for (int i = 0; i < numFish; i++)
        {
            position = new Vector3(
                                    Random.Range(-BoxSize, BoxSize), 
                                    Random.Range(-BoxSize, BoxSize), 
                                    Random.Range(-BoxSize, BoxSize)
                            );
            allFishs[i] = (GameObject) Instantiate(fishPreFab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 50) {
            goalPosition = new Vector3(
                                    Random.Range(-BoxSize, BoxSize), 
                                    Random.Range(-BoxSize, BoxSize), 
                                    Random.Range(-BoxSize, BoxSize)
                            );
        }
    }
}
