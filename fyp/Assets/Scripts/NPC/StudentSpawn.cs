using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawn : MonoBehaviour
{
    public GameObject student;
    public GameObject[] seatPos;

    void Start()
    {
        for(int i = 0; i < seatPos.Length; i++)
        {
            Instantiate(student, seatPos[i].transform.position, Quaternion.identity);
        }
    }
}
