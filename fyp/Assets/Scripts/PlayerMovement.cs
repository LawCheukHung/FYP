using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigi;
    public Camera playerCamera;
    public float velocity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += playerCamera.transform.forward * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= playerCamera.transform.right * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= playerCamera.transform.forward * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += playerCamera.transform.right * velocity * Time.deltaTime;
        }
    }
}
