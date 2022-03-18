using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject garbagePrefab;
    public GameObject chalkPrefab;
    public GameObject rulerPrefab;
    public GameObject brushPrefab;
    private GameObject spawnMissionObjectPrefab;
    private GameObject spawnShootingObjectPrefab;
    private Vector3 spawnPos;
    private float spawnMissionObjectTime = 10f;
    private float spawnShootingObjectTime = 8f;

    void Update()
    {
        countSpawnMissionObjectTime();
        countSpawnShootingObjectTime();
    }

    private void countSpawnMissionObjectTime()
    {
        if (spawnMissionObjectTime <= 0)
        {
            spawnMissionObject();
            initSpawnMissionObjectTime();
        }
        else
        {
            spawnMissionObjectTime -= Time.deltaTime;
        }
    }

    private void countSpawnShootingObjectTime()
    {
        if (spawnShootingObjectTime <= 0)
        {
            spawnShootingObject();
            initSpawnShootingObjectTime();
        }
        else
        {
            spawnShootingObjectTime -= Time.deltaTime;
        }
    }

    private void initSpawnMissionObjectTime()
    {
        spawnMissionObjectTime = 10f;
    }

    private void initSpawnShootingObjectTime()
    {
        spawnShootingObjectTime = 8f;
    }

    private void spawnMissionObject()
    {
        randomSpawnMissionObject();
        randomPosition();
        Instantiate(spawnMissionObjectPrefab, spawnPos, Quaternion.identity);
    }

    private void spawnShootingObject()
    {
        randomSpawnShootingObject();
        randomPosition();
        Instantiate(spawnShootingObjectPrefab, spawnPos, Quaternion.identity);
    }

    private void randomSpawnShootingObject()
    {
        int randNum = Random.Range(0, 3);

        switch (randNum)
        {
            case 0:
                spawnShootingObjectPrefab = chalkPrefab;
                break;
            case 1:
                spawnShootingObjectPrefab = rulerPrefab;
                break;
            case 2:
                spawnShootingObjectPrefab = brushPrefab;
                break;
            default:
                break;
        }
    }

    private void randomSpawnMissionObject()
    {
        int randNum = Random.Range(0, 3);

        switch (randNum)
        {
            case 0:
                spawnMissionObjectPrefab = garbagePrefab;
                break;
            case 1:
                spawnMissionObjectPrefab = garbagePrefab;
                break;
            case 2:
                spawnMissionObjectPrefab = garbagePrefab;
                break;
            default:
                break;
        }
    }

    private void randomPosition()
    {
        spawnPos = new Vector3(Random.Range(1.5f, 5f), -3.9f, Random.Range(-2.2f, -4f));
    }
}
