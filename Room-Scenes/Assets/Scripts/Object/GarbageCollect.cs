using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollect : MonoBehaviour
{
    private SideMission sideMission;

    void Start()
    {
        sideMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<SideMission>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GarbageBin"))
        {
            sideMission.countCollectGarbage();
            gameObject.SetActive(false);
        }
    }
}
