using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBikeControl : MonoBehaviour
{
    public float forceMagnitude;
    [Range(0f, 10f)] public float drag;
    public Transform[] bikeParts;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.drag = drag;
        if(Input.GetMouseButtonDown(0))
        {
            float dt = Time.deltaTime;
            Vector3 appiedForce = forceMagnitude * transform.forward * dt;
            rb.AddForce(appiedForce, ForceMode.Force);
        }

        float speed  = rb.velocity.magnitude;
        float angularSpeed = speed / 0.29f;
        float angle  = Mathf.Rad2Deg * Time.deltaTime * angularSpeed;
        for (int i = 0; i < bikeParts.Length; i++)
        {
            bikeParts[i].Rotate(0, 0, angle, Space.Self);
        }
    }
}
