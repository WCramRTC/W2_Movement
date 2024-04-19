using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Fast : MonoBehaviour
{
  public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 5f;
    public float doubleJumpForce = 5f;
    public float slideForce = 10f;
    public float slideDuration = 1f;
    public float crouchSpeed = 2f;
    public float crouchHeight = 0.5f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private bool isGrounded = false;
    private bool isSliding = false;
    private bool isCrouching = false;

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

        // Check if grounded
        isGrounded = characterController.isGrounded;

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            characterController.Move(Vector3.up * jumpForce);
        }

        // Double Jump
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            characterController.Move(Vector3.up * doubleJumpForce);
        }

        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
            if (isCrouching)
            {
                characterController.height = crouchHeight;
                moveSpeed /= crouchSpeed;
            }
            else
            {
                characterController.height = 2f;
                moveSpeed *= crouchSpeed;
            }
        }

        // Slide
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && !isSliding)
        {
            StartCoroutine(Slide());
        }

        // Movement
        float moveForward = Input.GetAxis("Vertical") * moveSpeed;
        float moveSideways = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = transform.forward * moveForward + transform.right * moveSideways;
        characterController.SimpleMove(movement);
    }

    IEnumerator Slide()
    {
        isSliding = true;
        float startTime = Time.time;

        while (Time.time < startTime + slideDuration)
        {
            characterController.Move(transform.forward * slideForce * Time.deltaTime);
            yield return null;
        }

        isSliding = false;
    }
}
