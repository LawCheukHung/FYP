using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawn : MonoBehaviour
{
    public GameObject student;
    public GameObject[] FirstseatPos;
    public GameObject[] SecondseatPos;
    public GameObject[] ThirdseatPos;

    void Start()
    {
        for (int i = 0; i < FirstseatPos.Length; i++)
            Instantiate(student, FirstseatPos[i].transform.position, Quaternion.identity);

        for (int i = 0; i < SecondseatPos.Length; i++)
            Instantiate(student, SecondseatPos[i].transform.position, Quaternion.identity);

        for (int i = 0; i < ThirdseatPos.Length; i++)
            Instantiate(student, ThirdseatPos[i].transform.position, Quaternion.identity);
    }
}
