using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGarbageMission : MonoBehaviour
{
    private int collectAmount = 0;

    public void addGarbageCollectAmount()
    {
        collectAmount++;
    }

    public int getcollectAmount()
    {
        return collectAmount;
    }
}
