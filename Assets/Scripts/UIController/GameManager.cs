using UnityEngine;
        
public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public int SceneNumber = 0;
    public int InteractionNumber = 0;
    
    void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}