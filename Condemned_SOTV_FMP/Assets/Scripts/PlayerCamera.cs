using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity;

    public Transform playerBody;
    public Polaroid polaroid;
    public int camSmooth;
    //public Computer computer;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }


    void FixedUpdate()
    {
        Cursor.visible = false;

        if (polaroid.GetComponent<Polaroid>().onExamine == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * camSmooth;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * camSmooth;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        //if (computer.GetComponent<Computer>().usingComputer == false)
        //{
        //    gameObject.GetComponent<PlayerCamera>().enabled = true;
        //}
    }
}
