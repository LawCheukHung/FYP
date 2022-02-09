using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollect : MonoBehaviour
{
    private CollectGarbageMission collectGarbageMission;
    private PlayerBehavior playerBehavior;

    void Start()
    {
        collectGarbageMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<CollectGarbageMission>();
        playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GarbageBin"))
        {
            collectGarbageMission.countTotalCollectGarbage();
            playerBehavior.dropTargetObject();
            gameObject.SetActive(false);
        }
    }
}
