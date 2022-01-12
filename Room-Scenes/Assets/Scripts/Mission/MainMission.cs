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
    private int badStudentAmount = 0;

    void Start()
    {
        timerText.text = "Lesson Remaining Time: " + (int)timer;
        teachingProgressText.text = "Teaching Progress: " + (int)teachingProgress + "%";
    }

    void Update()
    {
        Debug.Log(badStudentAmount);
        checkMainMission();
        changeTeachingProgress();
    }

    private void checkMainMission()
    {
        if (timer <= 0 || teachingProgress <= 0)
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
        if (isTeaching && badStudentAmount <= 0)
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

    public void changeBadStudentAmount(int changeValue)
    {
        badStudentAmount += changeValue;
    }
}
