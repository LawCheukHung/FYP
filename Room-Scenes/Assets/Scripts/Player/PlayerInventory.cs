using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject chalk;
    public GameObject ruler;
    public GameObject brush;
    private PlayerInventoryObjectState playerInventoryObjectState;
    private GameObject[] chalkArr;
    private GameObject[] rulerArr;
    private GameObject[] brushArr;
    private int chalkPivot = 0;
    private int rulerPivot = 0;
    private int brushPivot = 0;

    void Start()
    {
        chalkArr = new GameObject[5];
        rulerArr = new GameObject[5];
        brushArr = new GameObject[5];
        playerInventoryObjectState = PlayerInventoryObjectState.Null;
    }

    void Update()
    {
        listenPlayerInventoryChange();
    }

    private void listenPlayerInventoryChange()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            playerInventoryObjectState = PlayerInventoryObjectState.Chalk;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            playerInventoryObjectState = PlayerInventoryObjectState.Ruler;
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            playerInventoryObjectState = PlayerInventoryObjectState.Brush;
        }
    }

    public void showShootItem()
    {
        if (playerInventoryObjectState == PlayerInventoryObjectState.Chalk && chalkPivot > 0)
        {
            hideShootItem();
            chalk.SetActive(true);
        }
        else if (playerInventoryObjectState == PlayerInventoryObjectState.Ruler && rulerPivot > 0)
        {
            hideShootItem();
            ruler.SetActive(true);
        }
        else if (playerInventoryObjectState == PlayerInventoryObjectState.Brush && brushPivot > 0)
        {
            hideShootItem();
            brush.SetActive(true);
        }
        else
        {
            hideShootItem();
            playerInventoryObjectState = PlayerInventoryObjectState.Null;
        }
    }

    public void hideShootItem()
    {
        chalk.SetActive(false);
        ruler.SetActive(false);
        brush.SetActive(false);
    }

    public int getPlayerInventoryObjectState()
    {
        return (int)playerInventoryObjectState;
    }

    public int getPlayerInvertoryPivot(int state)
    {
        switch ((PlayerInventoryObjectState)state)
        {
            case PlayerInventoryObjectState.Chalk:
                return chalkPivot;
            case PlayerInventoryObjectState.Ruler:
                return rulerPivot;
            case PlayerInventoryObjectState.Brush:
                return brushPivot;
            default:
                return 0;
        }
    }

    public void registerShootingObject(ref GameObject shootingObject, int objectType)
    {
        switch (objectType)
        {
            case 1:
                chalkArr[chalkPivot] = shootingObject;
                shootingObject.SetActive(false);
                chalkPivot++;
                break;
            case 2:
                rulerArr[rulerPivot] = shootingObject;
                shootingObject.SetActive(false);
                rulerPivot++;
                break;
            case 3:
                brushArr[brushPivot] = shootingObject;
                shootingObject.SetActive(false);
                brushPivot++;
                break;
            default:
                break;
        }
    }

    public void releaseShootingObject(ref GameObject currentShootingObject)
    {
        switch (playerInventoryObjectState)
        {
            case PlayerInventoryObjectState.Chalk:
                currentShootingObject = chalkArr[chalkPivot];
                currentShootingObject.transform.position = chalk.transform.position;
                chalkArr[chalkPivot] = null;
                chalkPivot--;
                break;
            case PlayerInventoryObjectState.Ruler:
                currentShootingObject = rulerArr[rulerPivot];
                currentShootingObject.transform.position = ruler.transform.position;
                rulerArr[rulerPivot] = null;
                rulerPivot--;
                break;
            case PlayerInventoryObjectState.Brush:
                currentShootingObject = brushArr[brushPivot];
                currentShootingObject.transform.position = brush.transform.position;
                brushArr[brushPivot] = null;
                brushPivot--;
                break;
            default:
                break;
        }
    }
}
