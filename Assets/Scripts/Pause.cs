using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
    bool isPaused = false;

    private void start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (input.GetKeyDown(Keycode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timescale = 0;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

              
    }
 
}
