using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMission : MonoBehaviour
{
    public GamingUI gamingUI;
    public EndGameUI endGameUI;
    private float timer;
    private float teachingProgress;
    private float boostingMultiply;
    private bool isTeaching;
    private int badStudentAmount;

    void Start()
    {
        timer = 180f;
        teachingProgress = 100f;
        boostingMultiply = 1f;
        isTeaching = false;
        badStudentAmount = 0;
    }

    void Update()
    {
        mainMissionCountDown();
        teachingProgressCountDown();
    }

    private void mainMissionCountDown()
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

    private void teachingProgressCountDown()
    {
        if (badStudentAmount >= 0 && isTeaching)
        {
            if(teachingProgress < 100)
            {
                teachingProgress += boostingMultiply * Time.deltaTime;
            }
        }
        else
        {
            teachingProgress -= Time.deltaTime;
        }
    }

    public void boostTeachingProgress(float acceleration)
    {
        boostingMultiply = acceleration;
    }

    public void setIsTeaching(bool value)
    {
        isTeaching = value;
    }

    public void changeBadStudentAmount(int changeAmount)
    {
        badStudentAmount += changeAmount;
    }

    //for counting final score
    public float getTeachingProgress()
    {
        return teachingProgress;
    }

    public float getTimer()
    {
        return timer;
    }
}
