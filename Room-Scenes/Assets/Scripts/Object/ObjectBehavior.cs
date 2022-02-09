using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    private Rigidbody objectRigid;
    private PlayerBehavior playerBehavior;
    private bool isHoldingOnHand = false;

    private void Start()
    {
        objectRigid = transform.GetComponent<Rigidbody>();
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isHoldingOnHand)
        {
            playerBehavior.dropTargetObject();
            dropObject();
        }
    }

    public void grabObject(Transform parent)
    {
        gameObject.transform.SetParent(parent);
        objectRigid.useGravity = false;
        isHoldingOnHand = true;
    }

    public void dropObject()
    {
        gameObject.transform.SetParent(null);
        objectRigid.useGravity = true;
        isHoldingOnHand = false;
    }
}
