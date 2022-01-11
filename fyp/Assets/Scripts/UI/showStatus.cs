using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showStatus : MonoBehaviour
{
    private StudentBehavior studentStatus;
    public Text[] currentTextInfo;
    public Transform playerCamera;

    void Start()
    {
        for (int i = 0; i < currentTextInfo.Length; i++)
        {
            studentStatus = GameObject.Find("Student" + i).GetComponent<StudentBehavior>();
        }
    }

    void Update()
    {
        currentTextInfo[0].text = "Mental Value: " + (int)studentStatus.getMentalValue();
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
