using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Will change our scene to tge string passed in
    public void ChangeScene(string_scenename)
    {
        SceneManager.LoadScene(_sceneName);
    }

    //Reloads the current scene we are in
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Loads out Tutle scene, must be called title exactly
    public void ToTileScene()
    { 
        SceneManager.LoadScene(SceneManager"Title");
    }

    //Gets our active scene name
    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
  
    //Quits our game
    public void QuitGame()
    {
        Application.Quit();
    }
}
