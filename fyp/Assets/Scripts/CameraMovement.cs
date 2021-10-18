using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        playerCam.transform.eulerAngles = new Vector3();
    }
}
