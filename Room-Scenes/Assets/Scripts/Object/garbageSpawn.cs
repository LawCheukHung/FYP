using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawn : MonoBehaviour
{
    public GameObject garbagePrefab;
    private Vector3 garbagePosition;
    private bool isSpawn = false;
    private float spawnTime = 8;

    void Update()
    {
        countSpawnTime();

        if (isSpawn)
        {
            randomPosition();
            spawnGarbage();
        }
    }

    private void countSpawnTime()
    {
        if (spawnTime <= 0)
        {
            isSpawn = true;
            initSpawnTime();
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }

    private void initSpawnTime()
    {
        spawnTime = 5;
    }

    private void spawnGarbage()
    {
        Instantiate(garbagePrefab, garbagePosition, Quaternion.identity);
        isSpawn = false;
    }

    private void randomPosition()
    {
        garbagePosition = new Vector3(Random.Range(1.5f, 5f), -3.9f, Random.Range(-2.2f, -4f));
    }
}
