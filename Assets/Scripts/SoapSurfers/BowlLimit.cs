using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlLimit : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BowlLimit"))
        {
            float forceMagnitude = 10;
            float torqueMagnitude = 10;
            Vector3 force = forceMagnitude * (transform.position).normalized;
            rb.AddForce(force, ForceMode.Impulse);
            Vector3 torque = torqueMagnitude * Random.onUnitSphere;
            rb.AddTorque(torque, ForceMode.Impulse);
        }

    }
}
