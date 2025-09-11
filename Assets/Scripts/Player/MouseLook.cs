using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float smoothedMousePos;

    private float currentLookingPos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }
    private void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");

    }
    private void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing; // Scale input
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing); // Interpolate input
    }
    private void MovePlayer()
    {
        currentLookingPos += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }    
}
