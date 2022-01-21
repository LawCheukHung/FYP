using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GamingUI : MonoBehaviour
{
    public MainMission mainMission;
    public CollectGarbageMission collectGarbageMission;
    public Text teachingProgressText;
    public Text sideMissionText;
    public Text timerText;

    void Update()
    {
        teachingProgressText.text = "Teaching Progress: " + (int)mainMission.getTeachingProgress() + " %";
        sideMissionText.text = "Total Collected Garbage: " + collectGarbageMission.getTotalCollectGarbage();
        timerText.text = "Lesson Remaining Timer: " + (int)mainMission.getTimer();
    }
}
