using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public MainMission mainMission;
    public StudentControl studentControl;

    private PlayerSkillState playerSkillState;
    private float allCoolDownCountTime = 5f;
    private float teachingBoostCountTime = 3f;
    private bool isAllCoolDownTriggered = false;
    private bool isTeachingBoostTriggered = false;

    void Start()
    {
        playerSkillState = PlayerSkillState.teachingBoost;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && teachingBoostCountTime <= 0)
        {
            teachingBoost();
        }

        if (Input.GetKeyDown(KeyCode.G) && allCoolDownCountTime <= 0)
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
    }

    private void allCoolDown()
    {
        studentControl.initAllStudentMentalValue();
        isAllCoolDownTriggered = true;
    }

    private void teachingBoost()
    {
        mainMission.boostTeachingProgress(3f);
        isTeachingBoostTriggered = true;
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
            initAllCoolDownCountTime();
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
            initTeachingBoostCountTime();
        }
    }

    private void initAllCoolDownCountTime()
    {
        allCoolDownCountTime = 5f;
    }

    private void initTeachingBoostCountTime()
    {
        teachingBoostCountTime = 3f;
    }
}
