using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public Vector2 turn;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor to screen
    }
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X"); //gets mouse x and y input
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0); //turns mouse x and y input into turning the camera
    }
}
