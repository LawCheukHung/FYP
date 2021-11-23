using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float velocity = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log(playerCamera.transform.forward);
            transform.position += Vector3.Normalize(new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z)) * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.Normalize(new Vector3(playerCamera.transform.forward.x, 0, playerCamera.transform.forward.z)) * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.Normalize(new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z)) * velocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.Normalize(new Vector3(playerCamera.transform.right.x, 0, playerCamera.transform.right.z)) * velocity * Time.deltaTime;
        }
    }
}
