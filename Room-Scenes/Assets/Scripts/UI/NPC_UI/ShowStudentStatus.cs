using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowStudentStatus : MonoBehaviour
{
    public StudentBehavior studentBehavior;
    public Text currentStudentText;
    private Transform playerCamera;

    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void Update()
    {
        currentStudentText.text = "Mental Value: " + (int)studentBehavior.getMentalValue();
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
