using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera playerCam;
    private float camX, camY;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        camX = Screen.width / 2 + Input.GetAxis("Mouse X") * 10;
        camY = Screen.height / 2 + Input.GetAxis("Mouse Y") * 10;

        transform.LookAt(playerCam.ScreenToWorldPoint(new Vector3(camX, camY, playerCam.nearClipPlane)), Vector3.up);
    }
}
