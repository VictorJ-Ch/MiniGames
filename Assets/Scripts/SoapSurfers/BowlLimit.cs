using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float forceMagnitude = 1;
        float torqueMagnitude = 1;
        Vector3 force = forceMagnitude * (transform.position).normalized;
        rb.AddForce(force, ForceMode.Impulse);
        Vector3 torque = torqueMagnitude * Random.onUnitSphere;
        rb.AddTorque(torque, ForceMode.Impulse);
    }
}
