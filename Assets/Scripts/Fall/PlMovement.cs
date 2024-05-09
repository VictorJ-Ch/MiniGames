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
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
