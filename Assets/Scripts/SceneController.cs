using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Will change our scene to the string passed in
    public void ChangeScene(string _sceneName)
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
        GameController.instance.controlType = ControlType.Normal;
        SceneManager.LoadScene("Title");
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
