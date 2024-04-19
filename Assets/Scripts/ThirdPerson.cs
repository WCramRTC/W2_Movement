using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController characterController;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Rotation
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 targetDirection = new Vector3(horizontalInput, 0f, verticalInput);
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            characterController.Move(Vector3.up * jumpForce);
        }

        // Update Animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animator.SetBool("IsGrounded", isGrounded);
    }
}
