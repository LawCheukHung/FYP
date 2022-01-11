using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject teachingBook;
    public Camera playerCam;

    private GameObject currentGrabingObject;
    private GameObject currentCatchingStudent;
    private objectCollision grabbingObjectState;
    private StudentBehavior catchingStudentState;
    private TeacherState teacherState;
    private float aimingDistance = 1f;
    private float aimingRadius = 0.1f;
    private bool isHoldingObject = false;
    private int totalCaughtStudent = 0;

    void Start()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        Debug.Log("idle mode, caught student number: " + totalCaughtStudent);
=======
        Debug.Log(totalCaughtStudent);
>>>>>>> parent of 36fb1be (updates)
=======
        Debug.Log(totalCaughtStudent);
>>>>>>> parent of 36fb1be (updates)
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
                teachingBook.SetActive(false);
                initializeTeacherState();
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("idle mode, caught student number: " + totalCaughtStudent);
=======
>>>>>>> parent of 36fb1be (updates)
=======
>>>>>>> parent of 36fb1be (updates)
            }
            else
            {
                initializeTeacherState();
                teachingBook.SetActive(true);
                teacherState = TeacherState.Teach;
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("teach mode, caught student number: " + totalCaughtStudent);
=======
>>>>>>> parent of 36fb1be (updates)
=======
>>>>>>> parent of 36fb1be (updates)
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (teacherState == TeacherState.Catch)
            {
                initializeTeacherState();
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("idle mode, caught student number: " + totalCaughtStudent);
=======
>>>>>>> parent of 36fb1be (updates)
=======
>>>>>>> parent of 36fb1be (updates)
            }
            else
            {
                initializeTeacherState();
                teacherState = TeacherState.Catch;
<<<<<<< HEAD
<<<<<<< HEAD
                Debug.Log("catch mode, caught student number: " + totalCaughtStudent);
=======
>>>>>>> parent of 36fb1be (updates)
=======
>>>>>>> parent of 36fb1be (updates)
            }
        }
    }

    private void initializeTeacherState()
    {
        teacherState = TeacherState.Idle;
        teachingBook.SetActive(false);
        dropObject();
    }

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
            Debug.Log("catch mode");
>>>>>>> parent of 36fb1be (updates)
=======
            Debug.Log("catch mode");
>>>>>>> parent of 36fb1be (updates)
            shootRaycast();
        }
    }

    private void teachStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
<<<<<<< HEAD
<<<<<<< HEAD
            //teaching behavior
=======
            Debug.Log("teach mode");
>>>>>>> parent of 36fb1be (updates)
=======
            Debug.Log("teach mode");
>>>>>>> parent of 36fb1be (updates)
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
            Debug.Log("grab an object");
            currentGrabingObject.transform.SetParent(playerCam.transform);
            grabbingObjectState.setIsHolding(true);
            isHoldingObject = true;
        }
    }

    private void dropObject()
    {
        if (isHoldingObject)
        {
            Debug.Log("drop an object");
            currentGrabingObject.transform.SetParent(null);
            grabbingObjectState.setIsHolding(false);
            isHoldingObject = false;
        }
    }

    //when the grabbing object has collide with other gameObject, 
    //the objectCollision script will call this function to drop the current grabbing object.
    public void ObjectFall()
    {
        dropObject();
    }

    private void catchTargetStudent()
    {
        if (catchingStudentState.getIsBadBad())
        {
            catchingStudentState.initialiseStudentState();
            totalCaughtStudent++;
            Debug.Log(totalCaughtStudent);
        }
    }

    //for test raycast
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCam.transform.position + playerCam.transform.forward * aimingDistance, aimingRadius);
    }
}
