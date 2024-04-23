using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanController2 : MonoBehaviour
{
     public Transform LeftPlayer, RightPlayer;
    public float hitTime;
    private Animator animator;
    private Transform target;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = RightPlayer;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("LeftMove2");
            target = LeftPlayer;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("RightMove2");
            target = RightPlayer;
        }
    }

    public void EnableCollider()
    {
        bool isEnabled = GetComponent<BoxCollider>().enabled;
        GetComponent<BoxCollider>().enabled = !isEnabled;
    }

    private Vector3 HitVelocity(Transform target, Vector3 P0)
    {
        Vector3 Pf = target.position;
        Vector3 g = Physics.gravity;
        return (Pf - P0) / hitTime - 0.5f * g * hitTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bomb"))
        {
            Vector3 P0 = other.transform.position;
            Vector3 hitVelocity = HitVelocity(target, P0);
            Vector3 ramdomTorque = 100f * Random.onUnitSphere;

            other.GetComponent<Rigidbody>().velocity = hitVelocity;
            other.GetComponent<Rigidbody>().AddTorque(ramdomTorque, ForceMode.Impulse);
        }
    }
}
