using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollision : MonoBehaviour
{
    private Rigidbody objectRigid;
    private SideMission sideMission;
    private PlayerBehavior player;
    private bool isHolding = false;

    private void Start()
    {
        sideMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<SideMission>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        objectRigid = transform.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isHolding)
        {
            player.ObjectFall();
        }

        if (collision.gameObject.CompareTag("GarbageBin"))
        {
            sideMission.countCollectGarbage();
            gameObject.SetActive(false);
        }
    }

    public void setIsHolding(bool holdingState)
    {
        isHolding = holdingState;

        if (isHolding)
        {
            objectRigid.useGravity = false;
        }
        else
        {
            objectRigid.useGravity = true;
        }
    }
}
