using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageSpawn : MonoBehaviour
{
    public GameObject garbage;
    private bool isSpawn = false;
    private Vector3 garbagePosition;
    private float spawnTime = 5;
    private int totalGarbageAmount = 5;

    void Update()
    {
        countSpawnTime();

        if (isSpawn && totalGarbageAmount > 0)
        {
            randomPosition();
            spawnGarbage();
        }
    }

    private void countSpawnTime()
    {
        if(spawnTime <= 0)
        {
            isSpawn = true;
            spawnTime = 5;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }

    private void spawnGarbage()
    {
        Instantiate(garbage, garbagePosition, Quaternion.identity);
        isSpawn = false;
        totalGarbageAmount--;
    }

    private void randomPosition()
    {
        garbagePosition = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
    }
}
