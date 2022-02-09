using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Camera playerCam;
    public GameObject playerObject;
    public MainMission mainMission;

    private GameObject currentObject;
    private ObjectBehavior grabbingObject;
    private StudentBehavior catchingStudent;
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
                manipulateObject();
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
                playerObject.SetActive(true);
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
        playerObject.SetActive(false);
        mainMission.setIsTeaching(false);
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

    private void catchStudent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootRaycast();
        }
    }

    private void manipulateObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootRaycast();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            dropTargetObject();
        }
    }

    private void shootRaycast()
    {
        RaycastHit hit;

        if (Physics.SphereCast(playerCam.transform.position, aimingRadius, playerCam.transform.forward, out hit, aimingDistance))
        {
            if (hit.collider.tag == "Garbage" && playerState == PlayerState.Idle)
            {
                currentObject = hit.transform.gameObject;
                grabbingObject = currentObject.GetComponent<ObjectBehavior>();
                grabTargetObject();
            }

            if (hit.collider.tag == "Student" && playerState == PlayerState.Catch)
            {
                currentObject = hit.transform.gameObject;
                catchingStudent = currentObject.GetComponent<StudentBehavior>();
                catchTargetStudent();
            }

            if (hit.collider.tag == "Chalk" && playerState == PlayerState.Idle)
            {
                currentObject = hit.transform.gameObject;
            }
        }
    }

    private void grabTargetObject()
    {
        if (!isHoldingObject)
        {
            grabbingObject.grabObject(transform);
            isHoldingObject = true;
        }
    }

    public void dropTargetObject()
    {
        if (isHoldingObject)
        {
            isHoldingObject = false;
        }
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
