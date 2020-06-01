using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAsyncScene : Singleton<LoadAsyncScene>
{
    public bool isLoaded = false;
    public IEnumerator SceneLoader(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        yield return new WaitForSeconds(1.5f);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public bool IsLoaded()
    {
        return isLoaded;
    }
}