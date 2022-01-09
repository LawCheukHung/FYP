using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBehavior : MonoBehaviour
{
    public StudentState studentState;
    private float badValue;
    private float mentalValue;
    private bool isBadBad = false;

    void Start()
    {
        studentState = StudentState.Nice;
        badValue = Random.Range(0.01f, 0.1f);
        mentalValue = 100f;
    }

    void Update()
    {
        changeActionState();

        if (studentState != StudentState.Nice)
        {
            isBadBad = true;
        }
    }

    private void countDownMentalValue()
    {
        mentalValue -= badValue * Time.deltaTime;
    }

    private void changeActionState()
    {
        countDownMentalValue();

        if (mentalValue <= 0)
        {
            studentState = (StudentState)((int)Random.Range(0,3));
        }
    }

    public bool getIsBadBad()
    {
        return isBadBad;
    }
}
