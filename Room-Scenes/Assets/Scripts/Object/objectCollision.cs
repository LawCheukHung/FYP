using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private Rigidbody objectRigid;
    private PlayerBehavior playerBehavior;
    private bool isHolding = false;

    private void Start()
    {
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        objectRigid = transform.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isHolding)
        {
            playerBehavior.lostObject();
        }
    }

    public void setIsHolding(bool currentState)
    {
        isHolding = currentState;

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
