using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollect : MonoBehaviour
{
    private CollectGarbageMission collectGarbageMission;
    private ObjectBehavior objectBehavior;

    void Start()
    {
        collectGarbageMission = GameObject.FindGameObjectWithTag("Mission").GetComponent<CollectGarbageMission>();
        objectBehavior = gameObject.GetComponent<ObjectBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GarbageBin"))
        {
            collectGarbageMission.addGarbageCollectAmount();
            objectBehavior.dropObject();
            gameObject.SetActive(false);
        }
    }
}
