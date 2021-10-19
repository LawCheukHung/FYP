using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigi;
    public CameraMovement cameraMovement;
    public float velocity = 10f;

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
            Vector3 nInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerRigi.MovePosition(transform.position + nInput * velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 nInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerRigi.MovePosition(transform.position + nInput * velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 nInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerRigi.MovePosition(transform.position + nInput * velocity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 nInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerRigi.MovePosition(transform.position + nInput * velocity * Time.deltaTime);
        }
    }
}
