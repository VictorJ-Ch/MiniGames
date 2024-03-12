using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float torqueMagnitude;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (players)
        {
            case Players.Player1:
                movementPlayer1();
                break;
            case Players.Player2:
                movementPlayer2();
                break;
        }
    }

    public enum Players
    {
        Player1, Player2
    }

    public Players players;

    void movementPlayer1()
    {
        float hInput = Input.GetAxis("Horizontal-P1");
        float vInput = Input.GetAxis("Vertical-P1");
        Vector3 dirInput = new Vector3(hInput, 0, vInput).normalized;
        Vector3 torque = torqueMagnitude * Vector3.Cross(Vector3.up, dirInput);
        rb.AddTorque(torque * Time.deltaTime, ForceMode.Force);
    }

    void movementPlayer2()
    {
        float hInput = Input.GetAxis("Horizontal-P2");
        float vInput = Input.GetAxis("Vertical-P2");
        Vector3 dirInput = new Vector3(hInput, 0, vInput).normalized;
        Vector3 torque = torqueMagnitude * Vector3.Cross(Vector3.up, dirInput);
        rb.AddTorque(torque * Time.deltaTime, ForceMode.Force);
    }
}
