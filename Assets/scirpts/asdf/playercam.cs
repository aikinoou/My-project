using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercam : MonoBehaviour
{
    public float sensX; // x and y sens
    public float sensY;

    public Transform orientation; //direction its facing 

    float XRotation; //x and y rotation
    float YRotation;

    private void start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor to to the middle
        Cursor.visible = false; // cursor invis
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX; // mouse input
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        YRotation += mouseX;
        XRotation -= mouseY;

        
    }
}
