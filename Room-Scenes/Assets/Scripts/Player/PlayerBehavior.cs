using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Camera playerCam;
    public GameObject handsObjects;
    public MainMission mainMission;
    private GameObject currentGrabingObject;
    private GameObject currentCatchingStudent;
    private ObjectCollision grabbingObject;
    private StudentBehavior catchingStudent;
    private PlayerState playerState;
    private float aimingDistance = 1f;
    private float aimingRadius = 0.1f;
    private bool isHoldingObject = false;
    private bool isAfterTeaching = false;
    private int chalkAmount = 0;

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
                handsObjects.SetActive(true);
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
        handsObjects.SetActive(false);
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

        if (Input.GetMouseButton(1) && chalkAmount > 0 && !isAfterTeaching)
        {
            //shoot chalk
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
                grabbingObject = currentGrabingObject.GetComponent<ObjectCollision>();
                grabObject();
            }

            if (hit.collider.tag == "Student" && playerState == PlayerState.Catch)
            {
                currentCatchingStudent = hit.transform.gameObject;
                catchingStudent = currentCatchingStudent.GetComponent<StudentBehavior>();
                catchTargetStudent();
            }

            if (hit.collider.tag == "Chalk" && playerState == PlayerState.Idle)
            {
                currentGrabingObject = hit.transform.gameObject;
                grabbingObject = currentGrabingObject.GetComponent<ObjectCollision>();
                //call chalk script
            }
        }
    }

    private void grabObject()
    {
        if (!isHoldingObject)
        {
            currentGrabingObject.transform.SetParent(playerCam.transform);
            grabbingObject.setIsHolding(true);
            isHoldingObject = true;
        }
    }

    private void dropObject()
    {
        if (isHoldingObject)
        {
            currentGrabingObject.transform.SetParent(null);
            grabbingObject.setIsHolding(false);
            isHoldingObject = false;
        }
    }

    public void lostObject()
    {
        dropObject();
    }

    private void catchTargetStudent()
    {
        if (catchingStudent.getIsBadBehavingValue())
        {
            catchingStudent.initStudentState();
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
