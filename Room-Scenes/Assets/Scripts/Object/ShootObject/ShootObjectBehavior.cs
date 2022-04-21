using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObjectBehavior : MonoBehaviour
{
    private ShootObjectControlSystem shootObjectControlSystem;
    private ShootObjectState shootObjectState;
    private float rebornTime;
    private float currentCountTime;
    private bool isShoot;

    void Start()
    {
        rebornTime = 5f;
        isShoot = false;
        currentCountTime = rebornTime;
        shootObjectControlSystem = GameObject.Find("ObjectControlSystem").GetComponent<ShootObjectControlSystem>();
    }

    void Update()
    {
        if (isShoot)
        {
            countRebornTime();
        }
    }

    private void countRebornTime()
    {
        if(currentCountTime <= 0)
        {
            isShoot = false;
            currentCountTime = rebornTime;
            rebornToSystem();
        }
        else
        {
            currentCountTime -= Time.deltaTime;
        }
    }

    public void setIsShoot()
    {
        isShoot = true;
    }

    public void setObjectState(int value)
    {
        shootObjectState = (ShootObjectState)value;
    }

    private void rebornToSystem()
    {
        GameObject passGameObject = gameObject;
        shootObjectControlSystem.registerShootObject(ref passGameObject, (int)shootObjectState);
    }
}
