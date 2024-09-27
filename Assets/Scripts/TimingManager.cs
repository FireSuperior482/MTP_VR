using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject listpanel;
    [SerializeField] TMP_Text timerText, infoText;

    string whileplaying = "Collect All the items you remember in the basket. place the basket near door and click submit";


    private float startTime;
    private bool timerIsRunning = false, taketimer = false;
    public float timeToRun = 15 * 60; // 15 minutes in seconds


    void Start()
    {
        button.SetActive(false);
        listpanel.SetActive(true);

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
                button.SetActive(true);
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
        button.SetActive(false);
        listpanel.SetActive(true);
    }
}
