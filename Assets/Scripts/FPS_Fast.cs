using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Fast : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private CharacterController characterController;

    private float verticalRotation = 0;
    private Camera playerCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        characterController.SimpleMove(speed);
    }
}
