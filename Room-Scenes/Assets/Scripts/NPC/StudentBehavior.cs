using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBehavior : MonoBehaviour
{
    public StudentState studentState;
    private MainMission mainMission;
    private float badValue;
    private float mentalValue;
    private bool isBadBad = false;

    void Start()
    {
        mainMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<MainMission>();
        studentState = StudentState.Nice;
        badValue = Random.Range(1f, 1.5f);
        mentalValue = Random.Range(50f, 100f);
    }

    void Update()
    {
        if(mentalValue <= 0)
        {
            if(!isBadBad)
            changeActionState();
        }
        else
        {
            countDownMentalValue();
        }
    }

    public void initialiseStudentState()
    {
        studentState = StudentState.Nice;
        isBadBad = false;
        mentalValue = 100f;
    }

    private void countDownMentalValue()
    {
        mentalValue -= badValue * Time.deltaTime;
    }

    private void changeActionState()
    {
        studentState = (StudentState)((int)Random.Range(0, 3));
        isBadBad = true;
        mainMission.changeBadStudentAmount(1);
    }

    public bool getIsBadBad()
    {
        return isBadBad;
    }

    public float getMentalValue()
    {
        return mentalValue;
    }
}
