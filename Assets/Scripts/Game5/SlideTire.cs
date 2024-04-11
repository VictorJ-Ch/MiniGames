using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public string horizontalInputName, verticalInputName;
    public float forceMagnitude, jumpMagnitude;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float hInput = Input.GetAxis(horizontalInputName);
        float vInput = Input.GetAxis(verticalInputName);
        float dt = Time.deltaTime;
        Vector3 force = forceMagnitude * new Vector3(hInput, 0 ,vInput);
        GetComponent<Rigidbody>().AddForce(force * dt, ForceMode.Force);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ramp"))
        {
            Vector3 jumpForce = jumpMagnitude * transform.up;
            GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Force);
            print("Ramp");
        }
    }

}
