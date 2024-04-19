using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeController : MonoBehaviour
{

    public float speed = 2;
    public float jumpForce = 2;
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(1,1,1);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
                // Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);  

        Vector3 movement = new Vector3(x,0,z) * speed * Time.deltaTime;
        transform.Translate(movement);
        
        if(Input.GetButtonDown("Jump")) {
            rb.AddForce( Vector3.up* jumpForce, ForceMode.Impulse);
        }



        if(Input.GetButtonDown("Fire3")) {
            speed = 10;
            Debug.Log("Fire3 Down");

        }

        if(Input.GetButtonUp("Fire3")) {
            speed = 2;
            Debug.Log("Fire3 Up");
        }

    }
}
