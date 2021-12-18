using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera playerCamera;
    private float camX, camY;
    private Vector3 camRotate;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        camX = Screen.width / 2 + Input.GetAxis("Mouse X") * 10;
        camY = Screen.height / 2 + Input.GetAxis("Mouse Y") * 10;
        camRotate = new Vector3(camX, camY, playerCamera.nearClipPlane);

        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            transform.LookAt(playerCamera.ScreenToWorldPoint(camRotate), Vector3.up);
    }
}
