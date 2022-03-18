using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Camera playerCam;
    public MainMission mainMission;
    public PlayerTools playerTools;
    public PlayerInventory playerInventory;
    private PlayerBehaviorState playerBehaviorState;
    private GameObject currentShootingObject;
    private GameObject collectedObject;
    private GameObject target;
    private ObjectBehavior targetObject;
    private StudentBehavior targetStudent;
    private bool isHoldingObject = false;
    private bool isAfterTeaching = false;

    void Start()
    {
        playerBehaviorState = PlayerBehaviorState.Idle;
        Debug.Log("idle mode");
    }

    void Update()
    {
        listenPlayerBehaviorChange();
        switchPlayerBehaviorState();
    }

    private void switchPlayerBehaviorState()
    {
        switch (playerBehaviorState)
        {
            case PlayerBehaviorState.Catch:
                catching();
                break;
            case PlayerBehaviorState.Teach:
                teaching();
                break;
            case PlayerBehaviorState.Idle:
                picking();
                break;
            default:
                break;
        }
    }

    private void listenPlayerBehaviorChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(playerBehaviorState != PlayerBehaviorState.Teach)
            {
                initPlayerState();
                playerBehaviorState = PlayerBehaviorState.Teach;
                playerTools.showObject();
                playerInventory.setIsShowObject(true);
                Debug.Log("teach mode");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerBehaviorState != PlayerBehaviorState.Catch)
            {
                initPlayerState();
                playerBehaviorState = PlayerBehaviorState.Catch;
                Debug.Log("catch mode");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (playerBehaviorState != PlayerBehaviorState.Idle)
            {
                initPlayerState();
                playerBehaviorState = PlayerBehaviorState.Idle;
                Debug.Log("idle mode");
            }
        }
    }

    private void initPlayerState()
    {
        playerBehaviorState = PlayerBehaviorState.Idle;
        playerTools.hideObject();
        playerInventory.setIsShowObject(false);
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
            shootObject();
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
        else if (Input.GetMouseButton(1))
        {
            dropTargetObject();
        }
    }

    private void shootRaycast()
    {
        RaycastHit hit;

        if (Physics.SphereCast(playerCam.transform.position, 0.1f, playerCam.transform.forward, out hit, 1f))
        {
            if (hit.collider.tag == "Garbage" && playerBehaviorState == PlayerBehaviorState.Idle)
            {
                target = hit.transform.gameObject;
                targetObject = target.GetComponent<ObjectBehavior>();
                grabTargetObject();
            }

            if (hit.collider.tag == "Student" && playerBehaviorState == PlayerBehaviorState.Catch)
            {
                target = hit.transform.gameObject;
                targetStudent = target.GetComponent<StudentBehavior>();
                catchTargetStudent();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chalk") && playerInventory.getPlayerInvertoryPivot(1) < 5)
        {
            collectedObject = collision.gameObject;
            playerInventory.registerShootingObject(ref collectedObject, 1);
        }

        if (collision.gameObject.CompareTag("Ruler") && playerInventory.getPlayerInvertoryPivot(2) < 5)
        {
            collectedObject = collision.gameObject;
            playerInventory.registerShootingObject(ref collectedObject, 2);
        }

        if (collision.gameObject.CompareTag("Brush") && playerInventory.getPlayerInvertoryPivot(3) < 5)
        {
            collectedObject = collision.gameObject;
            playerInventory.registerShootingObject(ref collectedObject, 3);
        }
    }

    private void shootObject()
    {
        if(playerInventory.getPlayerInvertoryPivot(playerInventory.getPlayerInventoryObjectState()) > 0)
        {
            playerInventory.releaseShootingObject(ref currentShootingObject);
            //give currentShootingObject a force
        }
    }

    private void grabTargetObject()
    {
        if (!isHoldingObject)
        {
            targetObject.grabObject(playerCam.transform);
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
        if (targetStudent.getStudentState() != 0)
        {
            targetStudent.initStudentState();
            mainMission.changeBadStudentAmount(-1);
        }
    }

    //for test raycast
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCam.transform.position + playerCam.transform.forward * 1f, 0.1f);
    }
}
