using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBehavior : MonoBehaviour
{
    public StudentState studentState;
    private MainMission mainMission;
    private float badValue;
    private float mentalValue;
    private bool isBadBehaving;

    void Start()
    {
        mainMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<MainMission>();
        initStudentState();
        badValue = Random.Range(1f, 1.5f);
    }

    void Update()
    {
        if(mentalValue <= 0)
        {
            if(!isBadBehaving)
                changeStudentState();
        }
        else
        {
            decreaseMentalValue();
        }
    }

    public void initStudentState()
    {
        studentState = StudentState.Nice;
        isBadBehaving = false;
        mentalValue = Random.Range(80f, 100f);
    }

    private void decreaseMentalValue()
    {
        mentalValue -= badValue * Time.deltaTime;
    }

    private void changeStudentState()
    {
        studentState = (StudentState)((int)Random.Range(0, 3));
        isBadBehaving = true;
        mainMission.changeBadStudentAmount(1);
    }

    public bool getIsBadBehavingValue()
    {
        return isBadBehaving;
    }

    public float getMentalValue()
    {
        return mentalValue;
    }
}
