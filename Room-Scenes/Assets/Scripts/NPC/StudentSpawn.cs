using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawn : MonoBehaviour
{
    public GameObject studentPrefab;
    public GameObject[] studentSeatPos;
    private GameObject student;

    void Awake()
    {
        for (int i = 0; i < studentSeatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, studentSeatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + i;
        }
    }

    public int getTotalStudentSeatPos()
    {
        return studentSeatPos.Length;
    }
}
