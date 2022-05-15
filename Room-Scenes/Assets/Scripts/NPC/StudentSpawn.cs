using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawn : MonoBehaviour
{
    private GameObject student;
    public GameObject studentPrefab;
    public GameObject[] FirstSeatPos;
    public GameObject[] SecondSeatPos;
    public GameObject[] ThirdSeatPos;
    public GameObject[] FourthSeatPos;

    void Awake()
    {
        for (int i = 0; i < FirstSeatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, FirstSeatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + i;
        }
            

        for (int i = 0; i < SecondSeatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, SecondSeatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + (5 + i);
        }

        for (int i = 0; i < ThirdSeatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, ThirdSeatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + (10 + i);
        }

        for (int i = 0; i < FourthSeatPos.Length; i++)
        {
            student = Instantiate(studentPrefab, FourthSeatPos[i].transform.position, Quaternion.identity);
            student.name = "Student" + (15 + i);
        }
    }
}
