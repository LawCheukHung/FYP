using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDropDown : MonoBehaviour
{
    private int freeState = 1;

    void Update()
    {
        if (freeState > 0 && transform.position.y > 0.05f)
        {
            transform.position -= new Vector3(0, transform.position.y - Time.deltaTime, 0);
        }
    }

    public void setFreeState()
    {
        freeState *= -1;
    }
}
