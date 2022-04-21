using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    public StudentSpawn studentSpawn;
    private StudentBehavior[] student;
    private int totalStudentSeatPos;

    void Start()
    {
        totalStudentSeatPos = studentSpawn.getTotalStudentSeatPos();
        student = new StudentBehavior[totalStudentSeatPos];
        registerAllStudent();
    }

    public void initAllStudentMentalValue()
    {
        for(int i = 0; i < student.Length; i++)
        {
            student[i].initStudentState();
        }
    }

    public void registerAllStudent()
    {
        for(int i = 0; i < totalStudentSeatPos; i++)
        {
            student[i] = GameObject.Find("Student" + i).GetComponent<StudentBehavior>();
        }
    }
}
