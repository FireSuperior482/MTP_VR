using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    [SerializeField] GameObject checkbutton,play;
    [SerializeField] GameObject listpanel;
    [SerializeField] TMP_Text timerText, infoText;

    string whileplaying = "Collect All the items you remember in the basket. place the basket near door and click submit";
    string beforeplaying = "Click below button to start the game";
    string whileshowing = "You Need to Collect all above items\r\nRemeber them before the timer ends";

    private float startTime;
    private bool timerIsRunning = false, taketimer = false;
    public float timeToRun = 15 * 60; // 15 minutes in seconds


    void Start()
    {
        listpanel.SetActive(false);
        play.SetActive(true);
        checkbutton.SetActive(false);
        infoText.text = beforeplaying;
        timerText.text = "";
    }

    public void startgame()
    {
        checkbutton.SetActive(false);
        play.SetActive(false);
        listpanel.SetActive(true);
        infoText.text = whileshowing;

        startTime = Time.time;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            float t = timeToRun - (Time.time - startTime);
            string minutes = Mathf.FloorToInt(t / 60).ToString();
            string seconds = Mathf.FloorToInt(t % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;

            if (t <= 0)
            {
                timerIsRunning = false;
                checkbutton.SetActive(true);
                listpanel.SetActive(false);
                taketimer = true;
                startTime = Time.time;
                infoText.text = whileplaying;
                // Add your code here for when the timer expires
                Debug.Log("Timer expired!");
            }
        }
        if (taketimer)
        {
            float t = (Time.time - startTime);
            string minutes = Mathf.FloorToInt(t / 60).ToString();
            string seconds = Mathf.FloorToInt(t % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void check()
    {
        timerText.text = "";
        checkbutton.SetActive(false);
        play.SetActive(true);
        listpanel.SetActive(true);
        taketimer = false;
    }
}
