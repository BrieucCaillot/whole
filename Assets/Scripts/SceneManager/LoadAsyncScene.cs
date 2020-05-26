using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAsyncScene : Singleton<LoadAsyncScene>
{
    public IEnumerator SceneLoader()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}