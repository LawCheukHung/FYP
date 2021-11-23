using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherBehavior : MonoBehaviour
{
    public Rigidbody teacherRigi;
    public GameObject teachingBook;
    private bool isBookActive = false;

    // Start is called before the first frame update
    void Start()
    {
        teacherRigi = GetComponent<Rigidbody>();
        teachingBook = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        switchTeachingMode();
    }

    private void switchTeachingMode()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!isBookActive)
            {
                teachingBook.SetActive(true);
                isBookActive = true;
            }
            else
            {
                teachingBook.SetActive(false);
                isBookActive = false;
            }
        }
    }
}
