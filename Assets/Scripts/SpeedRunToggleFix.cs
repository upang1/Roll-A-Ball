using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedRunToggleFix : MonoBehaviour
{
    GameController gameController;
    Toggle toggle;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        toggle = GetComponent<Toggle>();
        StartCoroutine(FixSpeedRunToggle());
    }

    IEnumerator FixSpeedRunToggle()
    {
        yield return new WaitForEndOfFrame();
        if (gameController.gameType == GameType.SpeedRun)
            toggle.isOn = true;
        else
            toggle.isOn = false;

        toggle.onValueChanged.AddListener((value) => gameController.ToggleSpeedRun(toggle.isOn));
    }

}