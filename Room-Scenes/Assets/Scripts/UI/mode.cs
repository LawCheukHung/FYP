using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mode : MonoBehaviour
{
    private TeacherState teacherState;
    public Text catchMode, teachingMode;
    // Start is called before the first frame update
    void Start()
    {
        catchMode.color = Color.black;
        teachingMode.color = Color.black;
        teacherState = TeacherState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (teacherState != TeacherState.Catch)
            {
                teacherState = TeacherState.Catch;
            }
            else
            {
                teacherState = TeacherState.Idle;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (teacherState != TeacherState.Teach)
            {
                teacherState = TeacherState.Teach;
            }
            else
            {
                teacherState = TeacherState.Idle;
            }
        }
        switch (teacherState)
        {
            case TeacherState.Catch:
                teachingMode.color = Color.black;
                catchMode.color = Color.white;
                break;
            case TeacherState.Teach:
                catchMode.color = Color.black;
                teachingMode.color = Color.white;
                break;
            case TeacherState.Idle:
                catchMode.color = Color.black;
                teachingMode.color = Color.black;
                break;
            default:
                break;
        }
    }
}
