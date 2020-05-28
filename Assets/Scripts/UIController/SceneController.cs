using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    
    public static void Intro()
    {
        GameManager.SceneNumber = 0;
        SceneManager.LoadScene("IntroScene");
        AudioManager.PauseSound();
    }

    public static void BirdsScene()
    {
        GameManager.SceneNumber = 1;
        SceneManager.LoadScene("LeoSergeSceneBirds");
        AudioManager.Instance.PlaySound("Weather/Wind");
    }
    
    public static void BoidScene()
    {
        GameManager.SceneNumber = 2;
        SceneManager.LoadScene("Ocean");
        AudioManager.Instance.PlaySound("Water/Underwater");
    }
}
