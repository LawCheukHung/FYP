using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeachingBar : MonoBehaviour
{
    public Slider imageBar;
    public MainMission mission;
    float maxValue = 10;
    float currentValue = 5;
    // Start is called before the first frame update
    void Start()
    {
        imageBar.maxValue = mission.getTeachingProgress();
    }

    // Update is called once per frame
    void Update()
    {
        //currentValue = mission.getTimer();
        imageBar.value = mission.getTeachingProgress();
    }
}
