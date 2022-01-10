using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawn : MonoBehaviour
{
    private GameObject student;
    public GameObject studentPrefab;
    public GameObject[] FirstseatPos;
    public GameObject[] SecondseatPos;
    public GameObject[] ThirdseatPos;

    void Awake()
    {
        for (int i = 0; i < FirstseatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, FirstseatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + i;
        }
            

        for (int i = 0; i < SecondseatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, SecondseatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + (5 + i);
        }

        for (int i = 0; i < ThirdseatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, ThirdseatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + (10 + i);
        }
    }
}
