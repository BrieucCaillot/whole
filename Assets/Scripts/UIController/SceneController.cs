using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static SceneController Instance;

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
    
    public void Intro()
    {
        GameManager.Instance.SceneNumber = 0;
        SceneManager.LoadScene("BrieucScene");
        AudioManager.Instance.PauseSound();
    }

    public void BirdsScene()
    {
        GameManager.Instance.SceneNumber = 1;
        SceneManager.LoadScene("SergeScene-Birds 1");
        AudioManager.Instance.PlaySound("Weather/Wind");
    }
    public void BoidScene()
    {
        GameManager.Instance.SceneNumber = 2;
        SceneManager.LoadScene("LeoSceneFishes 1");
        AudioManager.Instance.PlaySound("Water/Underwater");
    }
}
