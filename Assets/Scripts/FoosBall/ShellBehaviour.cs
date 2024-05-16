using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public float minSpeedX, minSpeedZ, maxAbsoluteSpeed;
    public float speedIncrement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randomVector = Random.onUnitSphere;
        randomVector.y = 0f;
        rb.velocity = randomVector.normalized;
    }

    void Update()
    {
        LimitVelocity();
    }

    void LimitVelocity()
    {
        //Vector3 velocity = rb.velocity;
        float signVx = Mathf.Sign(rb.velocity.x);
        float signVz = Mathf.Sign(rb.velocity.z);

        if (Mathf.Abs(rb.velocity.x) < minSpeedX)
            rb.velocity = new Vector3(signVx * minSpeedX, 0, rb.velocity.z);

        if (Mathf.Abs(rb.velocity.z) < minSpeedZ)
            rb.velocity = new Vector3(rb.velocity.x, 0, signVz * minSpeedZ);

        if (rb.velocity.magnitude > maxAbsoluteSpeed)
            rb.velocity = maxAbsoluteSpeed * (rb.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("FoosballPlayer"))
        {
            minSpeedX += speedIncrement;
            minSpeedZ += speedIncrement;
        }
    }
}