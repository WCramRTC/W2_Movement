using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal"));

            // float x = Input.GetAxis("Horizontal");
            // float z = Input.GetAxis("Vertical");

            // Vector3 movement = new Vector3(.1f,0,.1f);

            // transform.position += movement;
        // transform.position = new Vector3(Input.GetKeyDown())
    }
}
