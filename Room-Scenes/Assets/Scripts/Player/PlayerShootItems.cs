using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootItems : MonoBehaviour
{
    public GameObject chalk;
    public GameObject ruler;
    public GameObject brush;

    private PlayerInventoryObjects playerInventoryObjects;
    private GameObject currentObject;
    private int chalkAmount = 0;
    private int rulerAmount = 0;
    private int brushAmount = 0;

    void Start()
    {
        playerInventoryObjects = PlayerInventoryObjects.Chalk;
        currentObject = chalk;
    }

    void Update()
    {
        listenPlayerScrollChange();
        switchObjectKinds();
    }

    private void listenPlayerScrollChange()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            playerInventoryObjects = PlayerInventoryObjects.Chalk;
            currentObject = chalk;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            playerInventoryObjects = PlayerInventoryObjects.Ruler;
            currentObject = ruler;
        }

        if (Input.GetKey(KeyCode.Keypad3))
        {
            playerInventoryObjects = PlayerInventoryObjects.Brush;
            currentObject = brush;
        }
    }

    private void switchObjectKinds()
    {
        switch (playerInventoryObjects)
        {
            case PlayerInventoryObjects.Chalk:
                initObjects();
                chalk.SetActive(true);
                break;
            case PlayerInventoryObjects.Ruler:
                initObjects();
                ruler.SetActive(true);
                break;
            case PlayerInventoryObjects.Brush:
                initObjects();
                brush.SetActive(true);
                break;
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
        if (playerShootItems.getCollectiveObjectKinds() == 0 && playerShootItems.getChalkAmount() > 0)
        {
            playerShootItems.setChalkAmount(-1);
        }
        else if (playerShootItems.getCollectiveObjectKinds() == 1 && playerShootItems.getRulerAmount() > 0)
        {
            playerShootItems.setRulerAmount(-1);
        }
        else if (playerShootItems.getCollectiveObjectKinds() == 2 && playerShootItems.getBrushAmount() > 0)
        {
            playerShootItems.setBrushAmount(-1);
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

    public int getChalkAmount()
    {
        return chalkAmount;
    }

    public int getRulerAmount()
    {
        return rulerAmount;
    }

    public int getBrushAmount()
    {
        return brushAmount;
    }

    public int getCollectiveObjectKinds()
    {
        return (int)playerInventoryObjects;
    }
}
