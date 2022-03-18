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
    private bool isShowObject = false;

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

        if (isShowObject)
        {
            showShootItem();
        }
        else
        {
            hideAllShootItem();
        }
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
            hideAllShootItem();
            chalk.SetActive(true);
        }
        else if (playerInventoryObjectState == PlayerInventoryObjectState.Ruler && rulerPivot > 0)
        {
            hideAllShootItem();
            ruler.SetActive(true);
        }
        else if (playerInventoryObjectState == PlayerInventoryObjectState.Brush && brushPivot > 0)
        {
            hideAllShootItem();
            brush.SetActive(true);
        }
        else
        {
            hideAllShootItem();
            playerInventoryObjectState = PlayerInventoryObjectState.Null;
        }
    }

    public void hideAllShootItem()
    {
        chalk.SetActive(false);
        ruler.SetActive(false);
        brush.SetActive(false);
    }

    public void setIsShowObject(bool showState)
    {
        isShowObject = showState;
    }

    public int getPlayerInventoryObjectState()
    {
        return (int)playerInventoryObjectState;
    }

    public int getPlayerInvertoryPivot(int objectType)
    {
        switch (objectType)
        {
            case 1:
                return chalkPivot;
            case 2:
                return rulerPivot;
            case 3:
                return brushPivot;
            default:
                return 0;
        }
    }

    public void registerShootingObject(ref GameObject registerObject, int objectType)
    {
        switch (objectType)
        {
            case 1:
                chalkArr[chalkPivot] = registerObject;
                registerObject.SetActive(false);
                chalkPivot++;
                break;
            case 2:
                rulerArr[rulerPivot] = registerObject;
                registerObject.SetActive(false);
                rulerPivot++;
                break;
            case 3:
                brushArr[brushPivot] = registerObject;
                registerObject.SetActive(false);
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
