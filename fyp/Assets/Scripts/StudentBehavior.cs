using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBehavior : MonoBehaviour
{
    public Rigidbody studentRigi;

    // Start is called before the first frame update
    void Start()
    {
        studentRigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
