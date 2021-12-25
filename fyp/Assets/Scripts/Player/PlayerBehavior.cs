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
        switchState();

        switch (teacherState)
        {
            case TeacherState.Catch:
                catchStudent();
                break;
            case TeacherState.Teach:
                teachStudent();
                break;
            case TeacherState.Idle:
                collectGarbage();
                break;
            default:
                break;
        }
    }

    private void switchState()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (teacherState == TeacherState.Teach)
            {
                initializeTeacherState();
            }
            else
            {
                initializeTeacherState();
                teachingBook.SetActive(true);
                teacherState = TeacherState.Teach;
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (teacherState == TeacherState.Catch)
            {
                initializeTeacherState();
            }
            else
            {
                initializeTeacherState();
                teacherState = TeacherState.Catch;
            }
        }
    }

    private void initializeTeacherState()
    {
        teachingBook.SetActive(false);
        teacherState = TeacherState.Idle;
    }

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("catch");
        }
    }

    private void teachStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("teach");
        }
    }

    private void collectGarbage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("collect");
        }
    }
}
