using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject teachingBook;
    public Camera playerCam;

    private GameObject currentGarbage;
    private TeacherState teacherState;
    private GameObject pickUpObject;
    private float aimingDistance = 1f;
    private float aimingRadius = 0.1f;
    private bool isHoldingGarbage = false;

    void Start()
    {
        teacherState = TeacherState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switchState();

        switch (teacherState)
        {
            case TeacherState.Catch:
                catchStudent();
                break;
            case TeacherState.Teach:
                teachStudent();
                break;
            case TeacherState.Idle:
                collectGarbage();
                break;
            default:
                break;
        }
    }

    private void switchState()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (teacherState == TeacherState.Teach)
            {
                initializeTeacherState();
            }
            else
            {
                initializeTeacherState();
                teachingBook.SetActive(true);
                teacherState = TeacherState.Teach;
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (teacherState == TeacherState.Catch)
            {
                initializeTeacherState();
            }
            else
            {
                initializeTeacherState();
                teacherState = TeacherState.Catch;
            }
        }
    }

    private void initializeTeacherState()
    {
        teachingBook.SetActive(false);
        teacherState = TeacherState.Idle;
    }

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("catch");
        }
    }

    private void teachStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("teach");
        }
    }

    private void collectGarbage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("collect");
            shootRaycast();
        }
    }

    private void shootRaycast()
    {
        RaycastHit hit;

        if (Physics.SphereCast(playerCam.transform.position, aimingRadius, playerCam.transform.forward, out hit, aimingDistance))
        {
            if(!isHoldingGarbage && hit.collider.tag == "Garbage")
            {
                currentGarbage = hit.transform.gameObject;
                pickUpGarbage();
            }
        }
    }

    private void pickUpGarbage()
    {
        Debug.Log("picked up a garbage");
        isHoldingGarbage = true;
        currentGarbage.GetComponent<objectDropDown>().setFreeState();
        currentGarbage.transform.SetParent(playerCam.transform);
    }

    //for test raycast
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCam.transform.position + playerCam.transform.forward * aimingDistance, aimingRadius);
    }
}
