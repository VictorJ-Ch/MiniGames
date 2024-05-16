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
        Vector3 velocity = rb.velocity;
        float signVx = Mathf.Sign(velocity.x);
        float signVz = Mathf.Sign(velocity.z);

        if (Mathf.Abs(velocity.x) < minSpeedX)
            rb.velocity = new Vector3(signVx * minSpeedX, 0, velocity.z);

        if (Mathf.Abs(velocity.z) < minSpeedZ)
            rb.velocity = new Vector3(velocity.x, 0, signVz * minSpeedZ);

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
