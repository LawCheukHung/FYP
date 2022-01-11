using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showStatus : MonoBehaviour
{
    public StudentBehavior studentStatus;
    public Text currentTextInfo;
    private Transform playerCamera;

    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void Update()
    {
        currentTextInfo.text = "Mental Value: " + (int)studentStatus.getMentalValue();
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
