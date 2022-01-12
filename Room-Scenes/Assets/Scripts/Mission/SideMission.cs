using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SideMission : MonoBehaviour
{
    public Text sideMissionText;
    private int totalCollectGarbage;

    void Start()
    {
        totalCollectGarbage = 0;
        sideMissionText.text = "Total Collected Garbage: " + totalCollectGarbage;
    }

    public void countCollectGarbage()
    {
        totalCollectGarbage++;
        sideMissionText.text = "Total Collected Garbage: " + totalCollectGarbage;
    }

    public int getTotalCollectGarbage()
    {
        return totalCollectGarbage;
    }
}
