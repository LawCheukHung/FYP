using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Camera playerCam;
    public GameObject teacherBook;
    public MainMission mainMission;
    private GameObject currentGrabingObject;
    private GameObject currentCatchingStudent;
    private ObjectCollision grabbingObjectState;
    private StudentBehavior catchingStudentState;
    private PlayerState playerState;
    private float aimingDistance = 1f;
    private float aimingRadius = 0.1f;
    private bool isHoldingObject = false;
    private bool isAfterTeaching = false;

    void Start()
    {
        playerState = PlayerState.Idle;
        Debug.Log("idle mode");
    }

    void Update()
    {
        switchState();

        switch (playerState)
        {
            case PlayerState.Catch:
                catchStudent();
                break;
            case PlayerState.Teach:
                teachStudent();
                break;
            case PlayerState.Idle:
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
            if (playerState == PlayerState.Teach)
            {
                initPlayerState();
                Debug.Log("idle mode");
            }
            else
            {
                initPlayerState();
                teacherBook.SetActive(true);
                playerState = PlayerState.Teach;
                Debug.Log("teach mode");
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerState == PlayerState.Catch)
            {
                initPlayerState();
                Debug.Log("idle mode");
            }
            else
            {
                initPlayerState();
                playerState = PlayerState.Catch;
                Debug.Log("catch mode");
            }
        }
    }

    private void initPlayerState()
    {
        playerState = PlayerState.Idle;
        teacherBook.SetActive(false);
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
            isAfterTeaching = true;
        }
        else
        {
            if (isAfterTeaching)
            {
                mainMission.setIsTeaching(false);
                isAfterTeaching = false;
            }
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
            if (hit.collider.tag == "Garbage" && playerState == PlayerState.Idle)
            {
                currentGrabingObject = hit.transform.gameObject;
                grabbingObjectState = currentGrabingObject.GetComponent<ObjectCollision>();
                grabObject();
            }

            if (hit.collider.tag == "Student" && playerState == PlayerState.Catch)
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
            Debug.Log("idle mode & grabbing an object");
            currentGrabingObject.transform.SetParent(playerCam.transform);
            grabbingObjectState.setIsHolding(true);
            isHoldingObject = true;
        }
    }

    private void dropObject()
    {
        if (isHoldingObject)
        {
            Debug.Log("idle mode & drop the object");
            currentGrabingObject.transform.SetParent(null);
            grabbingObjectState.setIsHolding(false);
            isHoldingObject = false;
        }
    }

    public void lostObject()
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
