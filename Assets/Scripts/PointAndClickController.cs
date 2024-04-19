using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickController : MonoBehaviour
{

    public float panSpeed = 20f; // Speed of camera movement
    public float panBorderThickness = 10f; // Thickness of the border where camera starts panning
    public float scrollSpeed = 20f; // Speed of camera zoom
    public float minY = 20f; // Minimum height of camera
    public float maxY = 120f; // Maximum height of camera
    public GameObject spherePrefab;

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits anything in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit by the ray has a collider
                if (hit.collider != null)
                {
                    // Log the name of the object clicked
                    Debug.Log("Clicked on: " + hit.collider.gameObject.name);

                    // You can perform any actions you want here based on the object clicked
                    // For example, you could trigger an event or interact with the object
                    // Instantiate a sphere at the hit position
                Instantiate(spherePrefab, hit.point, Quaternion.identity);
                }
            }
        } // Mouse Click and Raycast

             // Move camera with keyboard input
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        // Zoom camera with mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Apply the new position to the camera
        transform.position = pos;
    } // Update
}
