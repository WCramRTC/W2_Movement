using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Fast : MonoBehaviour
{
   public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;

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
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Movement
        float moveForward = Input.GetAxis("Vertical") * moveSpeed;
        float moveSideways = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = transform.forward * moveForward + transform.right * moveSideways;
        characterController.SimpleMove(movement);
    }
}
