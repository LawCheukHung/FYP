using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMission : MonoBehaviour
{
    public GamingUI gamingUI;
    public EndGameUI endGameUI;
    private float timer = 180f;
    private float teachingProgress = 100f;
    private bool isTeaching = false;
    private int badStudentAmount = 0;

    void Update()
    {
        checkMainMission();
        changeTeachingProgress();
    }

    private void checkMainMission()
    {
        if (timer <= 0 || teachingProgress <= 0)
        {
            endGameUI.setIsEndGame();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void changeTeachingProgress()
    {
        if (isTeaching && badStudentAmount <= 0)
        {
            if(teachingProgress < 100)
            {
                teachingProgress += Time.deltaTime;
            }
        }
        else
        {
            if(teachingProgress > 0)
            {
                teachingProgress -= Time.deltaTime;
            }
        }
    }

    public void setIsTeaching(bool currentState)
    {
        isTeaching = currentState;
    }

    public void changeBadStudentAmount(int changeAmount)
    {
        badStudentAmount += changeAmount;
    }

    public float getTeachingProgress()
    {
        return teachingProgress;
    }

    public float getTimer()
    {
        return timer;
    }
}
