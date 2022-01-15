using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject teachingBook;
    public Camera playerCam;
    public MainMission mainMission;

    private GameObject currentGrabingObject;
    private GameObject currentCatchingStudent;
    private objectCollision grabbingObjectState;
    private StudentBehavior catchingStudentState;
    private TeacherState teacherState;
    private float aimingDistance = 1f;
    private float aimingRadius = 0.1f;
    private bool isHoldingObject = false;

    void Start()
    {
        teacherState = TeacherState.Idle;
        Debug.Log("idle mode");
    }

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
                collectObject();
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
                Debug.Log("idle mode");
            }
            else
            {
                initializeTeacherState();
                teachingBook.SetActive(true);
                teacherState = TeacherState.Teach;
                Debug.Log("teach mode");
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (teacherState == TeacherState.Catch)
            {
                initializeTeacherState();
                Debug.Log("idle mode");
            }
            else
            {
                initializeTeacherState();
                teacherState = TeacherState.Catch;
                Debug.Log("catch mode");
            }
        }
    }

    private void initializeTeacherState()
    {
        teacherState = TeacherState.Idle;
        teachingBook.SetActive(false);
        mainMission.setIsTeaching(false);
        dropObject();
    }

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootRaycast();
        }
    }

    private void teachStudent()
    {
        if (Input.GetMouseButton(0))
        {
            mainMission.setIsTeaching(true);
        }
        else
        {
            mainMission.setIsTeaching(false);
        }
    }

    private void collectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootRaycast();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            dropObject();
        }
    }

    private void shootRaycast()
    {
        RaycastHit hit;

        if (Physics.SphereCast(playerCam.transform.position, aimingRadius, playerCam.transform.forward, out hit, aimingDistance))
        {
            if (hit.collider.tag == "Garbage" && teacherState == TeacherState.Idle)
            {
                currentGrabingObject = hit.transform.gameObject;
                grabbingObjectState = currentGrabingObject.GetComponent<objectCollision>();
                grabObject();
            }

            if (hit.collider.tag == "Student" && teacherState == TeacherState.Catch)
            {
                currentCatchingStudent = hit.transform.gameObject;
                catchingStudentState = currentCatchingStudent.GetComponent<StudentBehavior>();
                catchTargetStudent();
            }
        }
    }

    private void grabObject()
    {
        if (!isHoldingObject)
        {
            Debug.Log("idle mode & grab an object");
            currentGrabingObject.transform.SetParent(playerCam.transform);
            grabbingObjectState.setIsHolding(true);
            isHoldingObject = true;
        }
    }

    private void dropObject()
    {
        if (isHoldingObject)
        {
            Debug.Log("idle mode & drop an object");
            currentGrabingObject.transform.SetParent(null);
            grabbingObjectState.setIsHolding(false);
            isHoldingObject = false;
        }
    }

    public void ObjectFall()
    {
        dropObject();
    }

    private void catchTargetStudent()
    {
        if (catchingStudentState.getIsBadBad())
        {
            catchingStudentState.initialiseStudentState();
            mainMission.changeBadStudentAmount(-1);
        }
    }

    //for test raycast
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCam.transform.position + playerCam.transform.forward * aimingDistance, aimingRadius);
    }
}
