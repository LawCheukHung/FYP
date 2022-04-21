using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject[] missionObjects;
    public GameObject[] collectiveObjects;
    private Vector3 spawnPos;
    private float spawnMissionObjectTime = 10f;
    private float spawnCollectiveObjectTime = 8f;
    private float currentSpawnMissionObjectTime = 0f;
    private float currentSpawnCollectiveObjectTime = 0f;

    void Start()
    {
        currentSpawnMissionObjectTime = spawnMissionObjectTime;
        currentSpawnCollectiveObjectTime = spawnCollectiveObjectTime;
    }

    void Update()
    {
        countSpawnMissionObjectTime();
        countSpawnShootingObjectTime();
    }

    private void countSpawnMissionObjectTime()
    {
        if (currentSpawnMissionObjectTime <= 0)
        {
            spawnMissionObject();
            currentSpawnMissionObjectTime = spawnMissionObjectTime;
        }
        else
        {
            currentSpawnMissionObjectTime -= Time.deltaTime;
        }
    }

    private void countSpawnShootingObjectTime()
    {
        if (currentSpawnCollectiveObjectTime <= 0)
        {
            spawnCollectiveObject();
            currentSpawnCollectiveObjectTime = spawnCollectiveObjectTime;
        }
        else
        {
            currentSpawnCollectiveObjectTime -= Time.deltaTime;
        }
    }

    private void spawnMissionObject()
    {
        randomPosition();
        Instantiate(missionObjects[randomSpawnObjectState(0, 3)], spawnPos, Quaternion.identity);
    }

    private void spawnCollectiveObject()
    {
        randomPosition();
        Instantiate(collectiveObjects[randomSpawnObjectState(0, 3)], spawnPos, Quaternion.identity);
    }

    private int randomSpawnObjectState(int min, int max)
    {
        return Random.Range(min, max);
    }

    private void randomPosition()
    {
        spawnPos = new Vector3(Random.Range(1.5f, 5f), -3.9f, Random.Range(-2.2f, -4f));
    }
}
