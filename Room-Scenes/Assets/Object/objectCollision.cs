using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollision : MonoBehaviour
{
    private PlayerBehavior player;
    private bool isHolding = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isHolding)
        {
            player.ObjectFall();
        }
    }

    public void setIsHolding(bool holdingState)
    {
        isHolding = holdingState;

        if (isHolding)
        {
            transform.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            transform.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
