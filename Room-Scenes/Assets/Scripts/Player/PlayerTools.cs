using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public GameObject teacherBook;

    public void hideObject()
    {
        teacherBook.SetActive(false);
    }

    public void showObject()
    {
        teacherBook.SetActive(true);
    }
}
