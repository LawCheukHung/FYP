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
    private ShootObjectState shootObjectState;
    private GameObject currentShootingObject;
    private GameObject collectedObject;
    private GameObject target;
    private ObjectBehavior targetObject;
    private StudentBehavior targetStudent;
    private bool isTeaching;
    private bool isHoldingObject;

    void Start()
    {
        isTeaching = false;
        isHoldingObject = false;
        playerBehaviorState = PlayerBehaviorState.Idle;
    }

    void Update()
    {
        changePlayerBehavior();

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
        }
    }

    private void changePlayerBehavior()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(playerBehaviorState != PlayerBehaviorState.Teach)
            {
                initPlayerState();
                playerBehaviorState = PlayerBehaviorState.Teach;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerBehaviorState != PlayerBehaviorState.Catch)
            {
                initPlayerState();
                playerBehaviorState = PlayerBehaviorState.Catch;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            initPlayerState();
        }
    }

    private void initPlayerState()
    {
        playerTools.hideObject();
        playerInventory.hideObject();
        playerBehaviorState = PlayerBehaviorState.Idle;
    }

    private void teaching()
    {
        playerTools.showObject();
        playerInventory.showObject();

        if (Input.GetMouseButton(0))
        {
            mainMission.setIsTeaching(true);
            isTeaching = true;
        }
        else
        {
            mainMission.setIsTeaching(false);
            isTeaching = false;
        }

        if (Input.GetMouseButton(1) && !isTeaching)
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
        if (collision.gameObject.CompareTag("ChalkItem") && playerInventory.checkArrPivot(0) < 4)
        {
            collision.gameObject.SetActive(false);
            playerInventory.registerShootObject(0);
        }

        if (collision.gameObject.CompareTag("RulerItem") && playerInventory.checkArrPivot(1) < 4)
        {
            collision.gameObject.SetActive(false);
            playerInventory.registerShootObject(1);
        }

        if (collision.gameObject.CompareTag("BrushItem") && playerInventory.checkArrPivot(2) < 4)
        {
            collision.gameObject.SetActive(false);
            playerInventory.registerShootObject(2);
        }
    }

    private void shootObject()
    {
        currentShootingObject = playerInventory.releaseShootObject();

        if (currentShootingObject != null)
        {
            currentShootingObject.GetComponent<ShootObjectBehavior>().setIsShoot();
            // give force to currentShootingObject
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
