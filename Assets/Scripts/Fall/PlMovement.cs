using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from specified axis
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Normalize the movement vector to ensure constant speed in all directions
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Apply movement to the player's Rigidbody component
        rb.MovePosition(rb.position + movement);
    }
}
