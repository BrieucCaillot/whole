# whole
Whole 🐳


// mouvement de faux vol des oiseaux - jsp s'il faut garder

foreach (GameObject bird in allBirds)
    {
      float speedBird = Random.Range(-0.4f, 0.4f);
      float velocity = ReturnSinSpeed.sinSpeed(Time.time - bias, speedBird * amplitude, frequency, 0);
                
      bird.transform.position = new Vector3(bird.transform.position.x + velocity, bird.transform.position.y + velocity * 6, bird.transform.position.z + velocity);
                
      if (!needDive) {
        bird.transform.LookAt(CenterMountain.transform.position);
        bird.transform.eulerAngles = new Vector3(bird.transform.eulerAngles.x + (velocity * 500), bird.transform.eulerAngles.y, bird.transform.eulerAngles.z);
      }

  }
  
  // Positionnement en V
  
  public void setVPosition(List<GameObject> allBirds, Transform parent) {
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
    
    
 // Vol normal   
  public void normalFly(List<GameObject> allBirds, Transform parent) {
    parent.position = new Vector3(parent.position.x, parent.position.y, parent.position.z + 0.5f);
    foreach (GameObject bird in allBirds) {
        bird.transform.LookAt(new Vector3(100, 100, 100));
    }
  }


public int cameraIndex = 0;
private float speed = 0;
    

public void DiveBird(Transform parent) {
    Sequence seq = DOTween.Sequence();
        seq.Append(parent.DOMove(parent.position + new Vector3(0, 2f, 0), 0.4f).SetEase(Ease.InOutCubic));
        seq.Append(parent.DOMove(new Vector3(65, -320, 319), 1f).SetEase(Ease.InQuint));
  
  
  // Comme un timeout
        seq.PrependInterval(1);

        DOTween.To(() => RenderSettings.fogColor, x => RenderSettings.fogColor = x, Color.blue, 1f);
        DOTween.To(() => MainCamera.backgroundColor, x => MainCamera.backgroundColor = x, Color.blue, 1f);
  
  
  // Loading ocean scene
        seq.OnComplete(()=>
        {
            StartCoroutine(LoadAsyncScene.Instance.SceneLoader());
        });

   
    }


  // Camera handler 
  
  // à mettre dans une fonction pour changer de vue
   cameraIndex = 1;
   CameraHandler(cameraIndex);
    
   
    public void CameraHandler(int cameraIndex) {
        CinemachineCameras[cameraIndex].Priority = 10;
    }
