using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private int pickupCount;
    private Timer timer;
    private bool gameOver = false;
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;

    GameController gameController;

    [Header("UI Stuff")]
    public GameObject inGamePanel;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text winTimeText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        //Get the number of pickups in our scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;

        //Run the check pickups function
        SetCountText();
        //Get the timer object and start the timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
        // Turn on our in game panel
        inGamePanel.SetActive(true);
        //Turn off our win panel
        gameOverScreen.SetActive(false);
        resetPoint = GameObject.Find("Reset Point");
        originalColour = GetComponent<Renderer>().material.color;

        gameController = FindObjectOfType<GameController>();
        if (gameController.gameType == GameType.SpeedRun)
            StartCoroutine(timer.StartCountdown());
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (resetting)
            return;

        if (gameController.gameType == GameType.SpeedRun && !timer.IsTiming())
            return;

        if (gameController.controlType == ControlType.WorldTilt) 
            return;


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
    }

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
        {
            other.GetComponent<Particles>().CreateParticles();
            Destroy(other.gameObject);
            //Decrement the pickup count
            pickupCount -= 1;
            //Run the check pickups function
            SetCountText();
        }
    }

    private void Update()
    {
        timerText.text = "Time:" + timer.GetTime().ToString("F2");
    }


    void SetCountText()
    {
        //Print the number of pickups in our scene
        scoreText.text = "Pickups Left: " + pickupCount;

        if (pickupCount == 0)
        {
            WinGame();
        }
    }
    void WinGame()
    {
        //Set the gameOver to true
        gameOver = true;
        // Stop the timer
        timer.StopTimer();
        //Turn on our win panel
        gameOverScreen.SetActive(true);
        //Turn off our in game panel
        inGamePanel.SetActive(false);
        //Display the timer on the win time text

        winTimeText.text = "Your time was: " + timer.GetTime().ToString("F2");
        

        if (gameController.gameType == GameType.SpeedRun)
            timer.StopTimer();

        //Set the velocity of the rigid body to zero
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PinFall()
    {
        pickupCount += 0;
        SetCountText();
    }
}
