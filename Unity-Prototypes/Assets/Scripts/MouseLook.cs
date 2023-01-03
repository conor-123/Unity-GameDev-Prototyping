using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{


    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked; //Lock cursor to center of screen
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 5 ; //Time.deltaTime is amount of time that has passed since update function was called
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 5;

        xRotation -= mouseY; //Every frame decrease X rotation based on mouseY
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Makes sure you can't over rotate and look behind player


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Quaternion responsible for rotations in Unity
        playerBody.Rotate(Vector3.up * mouseX);  //Allows you to rotate mouse on X axis
        
    }
}
