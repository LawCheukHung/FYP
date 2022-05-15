using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public MainMission mainMission;
    public StudentControl studentControl;
    private float allCoolDownCountTime = 50f;
    private float teachingBoostCountTime = 30f;
    private float teachingBoostDuration = 8f;
    private bool isAllCoolDownTriggered = false;
    private bool isTeachingBoostTriggered = false;
    private bool isCountingTeachingBoostDuration = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isTeachingBoostTriggered)
        {
            teachingBoost();
        }

        if (Input.GetKeyDown(KeyCode.G) && !isAllCoolDownTriggered)
        {
            allCoolDown();
        }

        if (isTeachingBoostTriggered)
        {
            countTeachingBoostTime();
        }

        if (isAllCoolDownTriggered)
        {
            countAllCoolDownTime();
        }

        if(isCountingTeachingBoostDuration)
        {
            countTeachingBoostDuration();
        }
    }

    private void allCoolDown()
    {
        studentControl.initAllStudentMentalValue();
        isAllCoolDownTriggered = true;
    }

    private void teachingBoost()
    {
        //mainMission.boostTeachingProgress(3f);
        isTeachingBoostTriggered = true;
        isCountingTeachingBoostDuration = true;
    }

    private void countTeachingBoostDuration()
    {
        if (teachingBoostDuration > 0)
        {
            teachingBoostDuration -= Time.deltaTime;
        }
        else
        {
            //mainMission.boostTeachingProgress(1f);
            teachingBoostDuration = 8f;
            isCountingTeachingBoostDuration = false;
        }
    }

    private void countAllCoolDownTime()
    {
        if (allCoolDownCountTime > 0)
        {
            allCoolDownCountTime -= Time.deltaTime;
        }
        else
        {
            isAllCoolDownTriggered = false;
            allCoolDownCountTime = 50f;
        }
    }

    private void countTeachingBoostTime()
    {
        if (teachingBoostCountTime > 0)
        {
            teachingBoostCountTime -= Time.deltaTime;
        }
        else
        {
            isTeachingBoostTriggered = false;
            teachingBoostCountTime = 30f;
        }
    }
}
