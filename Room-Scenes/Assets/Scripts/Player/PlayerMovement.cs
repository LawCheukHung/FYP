using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float moveVelocity = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.Normalize(new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z)) * moveVelocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.Normalize(new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z)) * moveVelocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.Normalize(new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z)) * moveVelocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.Normalize(new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z)) * moveVelocity * Time.deltaTime;
        }
    }
}
