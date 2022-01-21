using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGarbageMission : MonoBehaviour
{
    private int totalCollectGarbage = 0;

    public void countTotalCollectGarbage()
    {
        totalCollectGarbage++;
    }

    public int getTotalCollectGarbage()
    {
        return totalCollectGarbage;
    }
}
