using DG.Tweening;
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
    public static void DiveBird(List<GameObject> allBirds, Transform parent) {
        Sequence seq = DOTween.Sequence();
        foreach (var bird in allBirds)
        {
            seq.Append(bird.transform.DOMove(bird.transform.position + new Vector3(0f, 2f, 0f), 0.5f).SetEase(Ease.InOutCubic));
            seq.Append(bird.transform.DOMove(Vector3.zero, 1f).SetEase(Ease.InQuint));
        }
    }
}
