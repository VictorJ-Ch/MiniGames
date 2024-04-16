using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBikeControl : MonoBehaviour
{
    public float forceMagnitude;
    [Range(0.0f, 10.0f)] public float drag;
    public Transform[] bikedParts;
    public KeyCode keycode;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(keycode))
        {
            rb.drag = drag;
            if(Input.GetKeyDown(keycode))
            {
                float dt = Time.deltaTime;
                Vector3 appliedForce = forceMagnitude * transform.forward * dt;
                rb.AddForce(appliedForce, ForceMode.Force);
            }
        }

        if(Input.GetKeyDown(keycode))
        {
            rb.drag = drag;
            if(Input.GetKeyDown(keycode))
            {
                float dt = Time.deltaTime;
                Vector3 appliedForce = forceMagnitude * transform.forward * dt;
                rb.AddForce(appliedForce, ForceMode.Force);
            }
        }

        if(Input.GetKeyDown(keycode))
        {
            rb.drag = drag;
            if(Input.GetKeyDown(keycode))
            {
                float dt = Time.deltaTime;
                Vector3 appliedForce = forceMagnitude * transform.forward * dt;
                rb.AddForce(appliedForce, ForceMode.Force);
            }
        }
        
            float speed = rb.velocity.magnitude;
            float angularSpeed = speed / 0.29f;
            float angle = Mathf.Rad2Deg * Time.deltaTime * angularSpeed;
            for(int i = 0; i < bikedParts.Length; i++)
            {
                bikedParts[i].Rotate(0,0,angle, Space.Self);
            }
    }
}