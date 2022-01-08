using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTouchGround : MonoBehaviour
{
    private bool isGround = false;

    void Update()
    {
        if (isGround)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    public void setIsPicking()
    {
        isGround = false;
    }
}
