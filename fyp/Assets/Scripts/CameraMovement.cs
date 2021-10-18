using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera playerCam;
    private float camX, camY;
    private float xSpeed = 5f;
    private float ySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camY -= xSpeed * Input.GetAxis("Mouse X");
        camX -= ySpeed * Input.GetAxis("Mouse Y");

        playerCam.transform.eulerAngles = new Vector3(camX, camY, 0f);
    }
}
