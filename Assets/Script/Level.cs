using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float timeBeforeLoad;

    public void LoadSplashScreen()
    {
        SceneManager.LoadScene("SplashScreen");
        LoadStartScene();
    }

    public void LoadStartScene()
    {
        StartCoroutine(StartSceneWithLoad());
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadNextScene()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        ExitGame();
    }

    public IEnumerator StartSceneWithLoad()
    {
        yield return new WaitForSeconds(timeBeforeLoad);
        SceneManager.LoadScene(1);
    }
    
}
