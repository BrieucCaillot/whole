using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class InstantiateObjects : MonoBehaviour
{
    //Global Object => change with fish and bird with individual scripts
    [SerializeField] private GameObject Object;
    
    private GameObject objectClone;
    private Vector3 position; 
    private int numberOfObjects = 0;

    private float BoxSize = 5.0f;
    void Start()
    {
    //    Instantiate(Object, new Vector3(0, 0, 0), Quaternion.identity);

    }
    void Update()
    {
        // Quaternion.identity == no rotation, perfet alignement with world 
        // Random Pos
        position = new Vector3(Random.Range(-BoxSize, BoxSize), Random.Range(-BoxSize, BoxSize), Random.Range(-BoxSize, BoxSize));

        // On left click
        if(Input.GetButtonDown("Fire1")) {
            objectClone = Instantiate(Object, position, Quaternion.identity);
            numberOfObjects += 1;
            CreateUniqueName(numberOfObjects);
            
        }
        if(Input.GetButtonDown("Jump")) {
            numberOfObjects -= 1;
            Destroy(objectClone, 0f);

            // DestroyObject(objectClone);
        }
    }
    void CreateUniqueName(int numberOfObjects) 
    {
        objectClone.name = "object " + GetNumberOfObjects(numberOfObjects) + "(x: " + position.x + ", y: " + position.y + ", z: " + position.z + ")";
        Debug.Log(objectClone.tag);


    }

    void DestroyObject(GameObject objectClone) 
    {
        Destroy(objectClone, 1.0f);
    }
    public static int GetNumberOfObjects(int numberOfObjects)
    {
        return numberOfObjects;
    }
}
