using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SideMission : MonoBehaviour
{
    public Text sideMissionText;
    private int totalCollectAmount;

    void Start()
    {
        totalCollectAmount = 0;
        sideMissionText.text = "Total Collected Garbage: " + totalCollectAmount;
    }

    public void countCollectGarbage()
    {
        totalCollectAmount++;
        sideMissionText.text = "Total Collected Garbage: " + totalCollectAmount;
    }
}
