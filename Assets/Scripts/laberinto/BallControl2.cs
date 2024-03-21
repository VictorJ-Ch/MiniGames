using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl2 : MonoBehaviour
{
    public float torqueMagnitude;
    public float Frebote;
    public enum Players
    {
        Player1, Player2
    }
    public Players players;

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
                MovementPlayer1();
                break;
            case Players.Player2:
                MovementPlayer2();
                break;
        }
    }

    void MovementPlayer1()
    {
        float hInput = Input.GetAxis("Horizontal-P1");
        float vInput = Input.GetAxis("Vertical-P1");
        Vector3 dirInput = new Vector3(hInput, 0, vInput).normalized;
        Vector3 torque = torqueMagnitude * Vector3.Cross(Vector3.up, dirInput);
        rb.AddTorque(torque * Time.deltaTime, ForceMode.Force);
    }

    void MovementPlayer2()
    {
        float hInput = Input.GetAxis("Horizontal-P2");
        float vInput = Input.GetAxis("Vertical-P2");
        Vector3 dirInput = new Vector3(hInput, 0, vInput).normalized;
        Vector3 torque = torqueMagnitude * Vector3.Cross(Vector3.up, dirInput);
        rb.AddTorque(torque * Time.deltaTime, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            Vector3 otherPosition = collision.rigidbody.position;
            Vector3 repulsionDir = transform.position - otherPosition;
            Vector3 repulsionForce = Frebote * (repulsionDir.normalized);
            GetComponent<Rigidbody>().AddForce(repulsionForce, ForceMode.Impulse);
        }
    }
}
