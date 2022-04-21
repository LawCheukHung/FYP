using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform rightHandPos;
    public ShootObjectControlSystem shootObjectControlSystem;
    private ShootObjectState shootObjectState;
    private GameObject[,] shootObjectArr;
    private GameObject currentOnHandShootObject;

    void Start()
    {
        shootObjectArr = new GameObject[3, 5];
        shootObjectState = ShootObjectState.Null;
    }

    void Update()
    {
        listenPlayerInventoryChange();
    }

    private void listenPlayerInventoryChange()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            shootObjectState = ShootObjectState.Chalk;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            shootObjectState = ShootObjectState.Ruler;
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            shootObjectState = ShootObjectState.Brush;
        }
    }

    public void showObject()
    {
        hideObject();

        if (shootObjectState == ShootObjectState.Chalk && checkArrPivot(0) >= 0)
        {
            currentOnHandShootObject = shootObjectArr[0, checkArrPivot(0)];
            currentOnHandShootObject.SetActive(true);
        }
        else if (shootObjectState == ShootObjectState.Ruler && checkArrPivot(1) >= 0)
        {
            currentOnHandShootObject = shootObjectArr[1, checkArrPivot(1)];
            currentOnHandShootObject.SetActive(true);
        }
        else if (shootObjectState == ShootObjectState.Brush && checkArrPivot(2) >= 0)
        {
            currentOnHandShootObject = shootObjectArr[2, checkArrPivot(2)];
            currentOnHandShootObject.SetActive(true);
        }
        else
        {
            shootObjectState = ShootObjectState.Null;
            currentOnHandShootObject = null;
            hideObject();
        }
    }

    public void hideObject()
    {
        if(currentOnHandShootObject != null)
        {
            currentOnHandShootObject.SetActive(false);
        }
    }

    public int checkArrPivot(int shootObjectState)
    {
        int pivot = -1;

        for (int i = 4; i >= 0; i--)
        {
            if (shootObjectArr[shootObjectState, i] != null)
            {
                pivot = i;
                return pivot;
            }
        }

        return pivot;
    }

    public int getShootObjectState()
    {
        return (int)shootObjectState;
    }

    public void registerShootObject(int collectObjectState)
    {
        int arrIndex;

        switch (collectObjectState)
        {
            case 0:
                arrIndex = checkArrPivot(0) + 1;
                shootObjectArr[0, arrIndex] = shootObjectControlSystem.releaseShootObject(0);
                shootObjectArr[0, arrIndex].transform.position = rightHandPos.position;
                shootObjectArr[0, arrIndex].transform.SetParent(rightHandPos);
                break;
            case 1:
                arrIndex = checkArrPivot(1) + 1;
                shootObjectArr[1, arrIndex] = shootObjectControlSystem.releaseShootObject(1);
                shootObjectArr[1, arrIndex].transform.position = rightHandPos.position;
                shootObjectArr[1, arrIndex].transform.SetParent(rightHandPos);
                break;
            case 2:
                arrIndex = checkArrPivot(2) + 1;
                shootObjectArr[2, arrIndex] = shootObjectControlSystem.releaseShootObject(2);
                shootObjectArr[2, arrIndex].transform.position = rightHandPos.position;
                shootObjectArr[2, arrIndex].transform.SetParent(rightHandPos);
                break;
        }
    }

    public GameObject releaseShootObject()
    {
        switch ((int)shootObjectState)
        {
            case 0:
                shootObjectArr[0, checkArrPivot(0)] = null;
                currentOnHandShootObject.transform.SetParent(null);
                return currentOnHandShootObject;
            case 1:
                shootObjectArr[1, checkArrPivot(1)] = null;
                currentOnHandShootObject.transform.SetParent(null);
                return currentOnHandShootObject;
            case 2:
                shootObjectArr[2, checkArrPivot(2)] = null;
                currentOnHandShootObject.transform.SetParent(null);
                return currentOnHandShootObject;
            default:
                return null;
        }
    }
}
