using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private PlayerSkillState playerSkillState;
    private StudentControl studentControl;
    private MainMission mainMission;
    private float allCoolDownCountTime;
    private float teachingBoostCountTime;

    void Start()
    {
        playerSkillState = PlayerSkillState.teachingBoost;
    }

    void Update()
    {
        switchPlayerSkillState();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            useSkill();
        }
    }

    private void switchPlayerSkillState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerSkillState = PlayerSkillState.teachingBoost;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerSkillState = PlayerSkillState.allCoolDown;
        }
    }

    private void useSkill()
    {
        switch ((int)playerSkillState)
        {
            case 0: teachingBoost();
                break;
            case 1: allCoolDown();
                break;
            default:
                break;
        }
    }

    private void allCoolDown()
    {
        
    }

    private void teachingBoost()
    {

    }

    public int getPlayerSkillState()
    {
        return (int)playerSkillState;
    }
}
