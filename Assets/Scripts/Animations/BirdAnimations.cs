using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimations : MonoBehaviour
{    
    public static bool isVPositionComplete = false;
    public static bool isDownToFishComplete = false;


    public static void setVPosition(List<GameObject> allBirds, Transform parent) {
        if(isVPositionComplete) return;
        Vector3 VBirdPosition = new Vector3(0, 1, 0);
        int leftV = 0;
        int rightV = 0;
        
        for (int i = 0; i < allBirds.Count; i++) {
            if(i%2==0 && i != 0) {
                leftV++;
                VBirdPosition = new Vector3(leftV, 1, -leftV);
            }
            if(i%2==1) {
                rightV++;
                VBirdPosition = new Vector3(rightV, 1, rightV);
            }

            allBirds[i].transform.position = Vector3.Slerp(allBirds[i].transform.position, parent.transform.position + VBirdPosition, 0.02f);
        }
        
    }
    public static void goDownToWater(List<GameObject> allBirds, Transform parent) {
        // if(!isDownToFishComplete)
        foreach (GameObject bird in allBirds)
            {
                // Vector3 randomBirdPosition = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
                // bird.transform.position = Vector3.Slerp(bird.transform.position, parent.transform.position + randomBirdPosition, 0.02f);
                // bird.transform.LookAt(new Vector3(-55, -20, 200));
                bird.transform.eulerAngles = new Vector3(0, 0, 55);

                
            }
            parent.transform.position = Vector3.Slerp(parent.transform.position, new Vector3(parent.transform.position.x, 0, parent.transform.position.z), 0.02f);
            // isDownToFishComplete = true;
        }
}
