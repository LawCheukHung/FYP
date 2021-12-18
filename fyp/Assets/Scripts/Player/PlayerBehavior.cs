using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject teachingBook;
    private TeacherState teacherState;

    void Start()
    {
        teacherState = TeacherState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switchMode();

        if(teacherState == TeacherState.Catch)
        {
            catchStudent();
        }
    }

    private void switchMode()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            teachMode();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            catchMode();
        }
    }

    private void teachMode()
    {
        if (teacherState == TeacherState.Teach)
        {
            idleMode();
        }
        else
        {
            idleMode();
            teachingBook.SetActive(true);
            teacherState = TeacherState.Teach;
        }
    }

    private void catchMode()
    {
        if (teacherState == TeacherState.Catch)
        {
            idleMode();
        }
        else
        {
            idleMode();
            teacherState = TeacherState.Catch;
        }
    }

    private void idleMode()
    {
        teachingBook.SetActive(false);
        teacherState = TeacherState.Idle;
    }

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fuck");
        }
    }
}
