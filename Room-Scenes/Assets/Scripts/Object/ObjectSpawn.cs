using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject garbagePrefab;
    public GameObject chalkPrefab;
    public GameObject brushPrefab;
    public GameObject rulerPrefab;

    private GameObject spawnObjectPrefab;
    private Vector3 spawnPos;
    private float spawnTime = 8;

    void Update()
    {
        countDownToSpawnObject();
    }

    private void countDownToSpawnObject()
    {
        if (spawnTime <= 0)
        {
            spawnObject();
            initSpawnTime();
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }

    private void initSpawnTime()
    {
        spawnTime = 8;
    }

    private void spawnObject()
    {
        randomSpawnObject();
        randomPosition();
        Instantiate(spawnObjectPrefab, spawnPos, Quaternion.identity);
    }

    private void randomSpawnObject()
    {
        float randNum = Random.Range(0, 2);

        switch (randNum)
        {
            case 0:
                spawnObjectPrefab = garbagePrefab;
                break;
            case 1:
                spawnObjectPrefab = chalkPrefab;
                break;
            case 2:
                spawnObjectPrefab = brushPrefab;
                break;
            case 3:
                spawnObjectPrefab = rulerPrefab;
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
