using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMission : MonoBehaviour
{
    public GameObject gamingUI;
    public GameObject endGameUI;
    public Text timerText;
    public Text teachingProgressText;
    private float timer = 180f;
    private float teachingProgress = 100f;
    private float teachingIncreaseSpeed = 1f;
    private bool isOccurBadStudent = false;
    private bool isTeaching = false;

    void Start()
    {
        timerText.text = "Lesson Remaining Time: " + (int)timer;
        teachingProgressText.text = "Teaching Progress: " + (int)teachingProgress + "%";
    }

    void Update()
    {
        countDownTimer();
        changeTeachingProgress();
    }

    private void countDownTimer()
    {
        if (timer <= 0)
        {
            Time.timeScale = 0;
            gamingUI.SetActive(false);
            endGameUI.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
            timerText.text = "Lesson Remaining Time: " + (int)timer;
        }
    }

    private void changeTeachingProgress()
    {
        if (isTeaching)
        {
            if(teachingProgress < 100)
            {
                teachingProgress += Time.deltaTime;
                teachingProgressText.text = "Teaching Progress: " + (int)teachingProgress + "%";
            }
        }
        else
        {
            teachingProgress -= Time.deltaTime;
            teachingProgressText.text = "Teaching Progress: " + (int)teachingProgress + "%";
        }
    }

    public void setIsTeaching(bool isTeachingState)
    {
        isTeaching = isTeachingState;
    }
}
