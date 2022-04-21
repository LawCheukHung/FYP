using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootObjectControlSystem : MonoBehaviour
{
    public GameObject chalkPrefab;
    public GameObject rulerPrefab;
    public GameObject brushPrefab;
    private GameObject[,] shootObjectArr;
    private GameObject releaseObject;

    void Start()
    {
        shootObjectArr = new GameObject[3, 5];

        for (int i = 0; i < 3; i++)
        {
            for(int r = 0; r < 5; r++)
            {
                switch (i)
                {
                    case 0:
                        shootObjectArr[i, r] = Instantiate(chalkPrefab, transform.position, Quaternion.identity);
                        shootObjectArr[i, r].GetComponent<ShootObjectBehavior>().setObjectState(0);
                        break;
                    case 1:
                        shootObjectArr[i, r] = Instantiate(rulerPrefab, transform.position, Quaternion.identity);
                        shootObjectArr[i, r].GetComponent<ShootObjectBehavior>().setObjectState(1);
                        break;
                    case 2:
                        shootObjectArr[i, r] = Instantiate(brushPrefab, transform.position, Quaternion.identity);
                        shootObjectArr[i, r].GetComponent<ShootObjectBehavior>().setObjectState(2);
                        break;
                }

                shootObjectArr[i, r].transform.SetParent(transform);
                shootObjectArr[i, r].SetActive(false);
            }
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

    public void registerShootObject(ref GameObject shootObject, int shootObjectState)
    {
        int arrIndex;

        switch (shootObjectState)
        {
            case 0:
                arrIndex = checkArrPivot(0) + 1;
                shootObjectArr[0, arrIndex] = shootObject;
                shootObjectArr[0, arrIndex].transform.SetParent(transform);
                shootObjectArr[0, arrIndex].SetActive(false);
                break;
            case 1:
                arrIndex = checkArrPivot(1) + 1;
                shootObjectArr[1, arrIndex] = shootObject;
                shootObjectArr[1, arrIndex].transform.SetParent(transform);
                shootObjectArr[1, arrIndex].SetActive(false);
                break;
            case 2:
                arrIndex = checkArrPivot(2) + 1;
                shootObjectArr[2, arrIndex] = shootObject;
                shootObjectArr[2, arrIndex].transform.SetParent(transform);
                shootObjectArr[2, arrIndex].SetActive(false);
                break;
        }
    }

    public GameObject releaseShootObject(int shootObjectKind)
    {
        switch (shootObjectKind)
        {
            case 0:
                releaseObject = shootObjectArr[0, checkArrPivot(0)];
                releaseObject.transform.SetParent(null);
                shootObjectArr[0, checkArrPivot(0)] = null;
                return releaseObject;
            case 1:
                releaseObject = shootObjectArr[1, checkArrPivot(1)];
                releaseObject.transform.SetParent(null);
                shootObjectArr[1, checkArrPivot(1)] = null;
                return releaseObject;
            case 2:
                releaseObject = shootObjectArr[2, checkArrPivot(2)];
                releaseObject.transform.SetParent(null);
                shootObjectArr[2, checkArrPivot(2)] = null;
                return releaseObject;
            default:
                return null;
        }
    }
}
