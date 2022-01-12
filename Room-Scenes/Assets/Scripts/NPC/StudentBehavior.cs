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
        badValue = Random.Range(1f, 3f);
        mentalValue = 100f;
    }

    void Update()
    {
        if(mentalValue <= 0)
        {
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
