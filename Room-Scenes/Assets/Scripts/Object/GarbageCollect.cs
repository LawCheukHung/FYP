using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollect : MonoBehaviour
{
    private CollectGarbageMission collectGarbageMission;

    void Start()
    {
        collectGarbageMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<CollectGarbageMission>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GarbageBin"))
        {
            collectGarbageMission.countTotalCollectGarbage();
            gameObject.SetActive(false);
        }
    }
}
