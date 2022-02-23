using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Camera playerCam;
    public GameObject playerObject;
    public MainMission mainMission;

    private GameObject target;
    private ObjectBehavior targetObject;
    private StudentBehavior targetStudent;
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
                catching();
                break;
            case PlayerState.Teach:
                teaching();
                break;
            case PlayerState.Idle:
                picking();
                break;
            default:
                break;
        }
    }

    private void switchState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(playerState != PlayerState.Teach)
            {
                initPlayerState();
                playerObject.SetActive(true);
                playerState = PlayerState.Teach;
                Debug.Log("teach mode");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerState != PlayerState.Catch)
            {
                initPlayerState();
                playerState = PlayerState.Catch;
                Debug.Log("catch mode");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerState != PlayerState.Idle)
            {
                initPlayerState();
                playerState = PlayerState.Idle;
                Debug.Log("idle mode");
            }
        }
    }

    private void initPlayerState()
    {
        playerState = PlayerState.Idle;
        playerObject.SetActive(false);
    }

    private void teaching()
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

        if(Input.GetMouseButton(1) && !isAfterTeaching)
        {
            //shoot objects
        }
    }

    private void catching()
    {
        if (Input.GetMouseButton(0))
        {
            shootRaycast();
        }
    }

    private void picking()
    {
        if (Input.GetMouseButton(0))
        {
            shootRaycast();
        }
        else
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
                target = hit.transform.gameObject;
                targetObject = target.GetComponent<ObjectBehavior>();
                grabTargetObject();
            }

            if (hit.collider.tag == "Chalk" && playerState == PlayerState.Idle)
            {
                target = hit.transform.gameObject;
            }

            if (hit.collider.tag == "Student" && playerState == PlayerState.Catch)
            {
                target = hit.transform.gameObject;
                targetStudent = target.GetComponent<StudentBehavior>();
                catchTargetStudent();
            }
        }
    }

    private void grabTargetObject()
    {
        if (!isHoldingObject)
        {
            targetObject.grabObject(transform);
            isHoldingObject = true;
        }
    }

    public void dropTargetObject()
    {
        if (isHoldingObject)
        {
            targetObject.dropObject();
            isHoldingObject = false;
        }
    }

    private void catchTargetStudent()
    {
        if (targetStudent.getStudentState() == 0)
        {
            targetStudent.initStudentState();
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
