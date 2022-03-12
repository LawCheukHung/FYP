using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject chalk;
    public GameObject ruler;
    public GameObject brush;

    private PlayerInventoryObjectState playerInventoryObjectState;
    private GameObject currentObject;
    private int chalkAmount = 0;
    private int rulerAmount = 0;
    private int brushAmount = 0;

    void Start()
    {
        playerInventoryObjectState = PlayerInventoryObjectState.Null;
        currentObject = null;
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
            currentObject = chalk;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            playerInventoryObjectState = PlayerInventoryObjectState.Ruler;
            currentObject = ruler;
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            playerInventoryObjectState = PlayerInventoryObjectState.Brush;
            currentObject = brush;
        }
    }

    private void initObjects()
    {
        chalk.SetActive(false);
        ruler.SetActive(false);
        brush.SetActive(false);
    }

    public void showShootItem()
    {
        if (playerInventoryObjectState == PlayerInventoryObjectState.Chalk && chalkAmount > 0)
        {
            setChalkAmount(-1);
        }
        else if (playerInventoryObjectState == PlayerInventoryObjectState.Ruler && rulerAmount > 0)
        {
            setRulerAmount(-1);
        }
        else if (playerInventoryObjectState == PlayerInventoryObjectState.Brush && brushAmount > 0)
        {
            setBrushAmount(-1);
        }

        currentObject.SetActive(true);
    }

    public void hideShootItem()
    {
        currentObject.SetActive(false);
    }

    public void setChalkAmount(int change)
    {
        chalkAmount += change;
    }

    public void setRulerAmount(int change)
    {
        rulerAmount += change;
    }

    public void setBrushAmount(int change)
    {
        brushAmount += change;
    }
}
