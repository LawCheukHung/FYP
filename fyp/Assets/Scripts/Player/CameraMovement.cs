using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerBody;

    //private Vector3 camRotate;
    private float xRotation = 0f;
    private float mouseX, mouseY;
    private float mouseSensitivity = 200f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //camRotate = new Vector3(camX, camY, Camera.main.nearClipPlane);
        //transform.LookAt(Camera.main.ScreenToWorldPoint(camRotate), Vector3.up);
    }
}
