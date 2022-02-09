using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject garbagePrefab;
    public GameObject chalkPrefab;
    private GameObject spawnObjectPrefab;
    private Vector3 spawnPos;
    private bool isSpawn = false;
    private float spawnTime = 8;

    void Update()
    {
        countSpawnTime();

        if (isSpawn)
        {
            randomPosition();
            randomSpawnItem();
            spawnObject();
        }
    }

    private void randomSpawnItem()
    {
        float randNum = Random.Range(0, 1);

        if (randNum < 0.5)
        {
            spawnObjectPrefab = garbagePrefab;
        }
        else
        {
            spawnObjectPrefab = chalkPrefab;
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

    private void spawnObject()
    {
        Instantiate(spawnObjectPrefab, spawnPos, Quaternion.identity);
        isSpawn = false;
    }

    private void randomPosition()
    {
        spawnPos = new Vector3(Random.Range(1.5f, 5f), -3.9f, Random.Range(-2.2f, -4f));
    }
}
