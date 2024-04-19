using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Horizontal movement
    // Horizontal movement
    float horizontalInput = Input.GetAxis("Horizontal");
    Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

    rb.MovePosition(transform.position + movement);

    if(isGrounded) {Debug.Log("Is Grounded");}

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump works");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
