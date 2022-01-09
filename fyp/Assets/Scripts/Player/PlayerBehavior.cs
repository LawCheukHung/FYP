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
        teacherState = TeacherState.Idle;
        dropObject();
    }

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("catch mode");
            shootRaycast();
        }
    }

    private void teachStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("teach mode");
        }
    }

    private void collectObject()
    {
        if (Input.GetMouseButtonDown(0) && !isHoldingObject)
        {
            Debug.Log("collect mode (pick)");
            shootRaycast();
        }
        else if (Input.GetMouseButtonDown(1) && isHoldingObject)
        {
            Debug.Log("collect mode (drop)");
            dropObject();
        }
    }

    private void shootRaycast()
    {
        RaycastHit hit;

        if (Physics.SphereCast(playerCam.transform.position, aimingRadius, playerCam.transform.forward, out hit, aimingDistance))
        {
            if (hit.collider.tag == "Garbage")
            {
                currentGrabingObject = hit.transform.gameObject;
                grabbingObjectState = currentGrabingObject.GetComponent<objectCollision>();
                grabObject();
            }

            if (hit.collider.tag == "Student")
            {
                currentCatchingStudent = hit.transform.gameObject;
                catchingStudentState = currentCatchingStudent.GetComponent<StudentBehavior>();
                catchTargetStudent();
            }
        }
    }

    private void grabObject()
    {
        Debug.Log("grab an object");

        currentGrabingObject.transform.SetParent(playerCam.transform);
        grabbingObjectState.setIsHolding(true);
        isHoldingObject = true;
    }

    private void dropObject()
    {
        Debug.Log("drop an object");

        currentGrabingObject.transform.SetParent(null);
        grabbingObjectState.setIsHolding(false);
        isHoldingObject = false;
    }

    //when the grabbing object has collide with other gameObject, 
    //the objectCollision script will call this function to drop the current grabbing object.
    public void ObjectFall()
    {
        dropObject();
    }

    private void catchTargetStudent()
    {

    }

    //for test raycast
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCam.transform.position + playerCam.transform.forward * aimingDistance, aimingRadius);
    }
}
