using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPlayer : MonoBehaviour
{
    [Range(0, 20)] public float jumpImpulse;
    [Range(-20f, 1f)] public float gravity;
    private bool grounded;
    private Rigidbody rb;
    public KeyCode keycode;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        
        if( grounded && Input.GetKeyDown(keycode))
        {
            rb.AddForce(jumpImpulse * transform.up, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
