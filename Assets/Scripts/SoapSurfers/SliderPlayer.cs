using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SliderPlayer : MonoBehaviour
{
    public string horizontalInputName, verticalInputName;
    public float forceMagnitude, torqueMagnitude;
    public LayerMask bowlLayer;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementControl2();
        Rotationrectification();
    }

    void Rotationrectification()
    {
        RaycastHit hit; 
        if(Physics.Raycast(transform.position, -transform.up, out hit, 10, bowlLayer))
        {
            Vector3 newUp = hit.normal;
            Vector3 newForward = transform.forward - Vector3.Dot(transform.forward, newUp) * newUp;
            transform.rotation = Quaternion.LookRotation(newForward, newUp);
        }
    }

    void MovementControl2()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis(horizontalInputName);
        float vInput = Input.GetAxis(verticalInputName);

        Vector3 InputDir = new Vector3(hInput, 0, vInput).normalized;
        Vector3 newDir =  InputDir - Vector3.Dot(InputDir, transform.up) * transform.up;
        Vector3 force = forceMagnitude * newDir * dt;
        rb.AddForce(force, ForceMode.Force);
    }
}
