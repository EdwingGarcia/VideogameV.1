using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float sensMouse = 80f;
    public Transform cuerpoPlayer;
    float xrotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensMouse * Time.deltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        cuerpoPlayer.Rotate(Vector3.up * mouseX);

    }
}
