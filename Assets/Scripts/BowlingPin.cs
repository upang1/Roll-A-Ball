using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    bool knockedOver = false;
    PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //A pin is only considered knocked over if its past halfway on its rotation
        if (transform.up.y < 0.5f && !knockedOver)
        {
            playerController.PinFall();
            knockedOver = true;
        }
    }
}