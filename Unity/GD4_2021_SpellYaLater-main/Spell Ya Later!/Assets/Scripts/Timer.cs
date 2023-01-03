using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float timeRemaining = 600;
    public double crowdTimer = 60;
    public bool timerIsRunning = false;
    public Text timeText;
    public AudioClip[] crowd;
    public AudioSource crowdSource;
    private int selectCrowd;
    private float crowdPitch;

    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        crowdPitch = Random.Range(0.8f, 1.1f);
        selectCrowd = Random.Range(0, crowd.Length);    
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                crowdTimer -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("TestSceneJulian");
            }

            if(crowdTimer < 0){
                crowdSource.clip = crowd[selectCrowd];
                crowdSource.pitch = crowdPitch;
                crowdSource.PlayOneShot(crowdSource.clip);

                crowdTimer = 60;
                crowdPitch = Random.Range(0.8f, 1.1f);
                selectCrowd = Random.Range(0, crowd.Length);  
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

