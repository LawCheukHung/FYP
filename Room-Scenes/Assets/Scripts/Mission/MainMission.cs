using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMission : MonoBehaviour
{
    public EndGame endGame;
    public Text timerText;
    public Text teachingProgressText;
    private float timer = 180f;
    private float teachingProgress = 100f;
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
            endGame.setIsEndGame();
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

    public float getTeachingProgress()
    {
        return teachingProgress;
    }
}
