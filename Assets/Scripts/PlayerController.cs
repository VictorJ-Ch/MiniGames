using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController character;

    public float Walk = 6.0f;
    public float Jump = 10f;
    public float Gravity = 15f;
    public float Run = 25f;

 
    private Vector3 movimiento = Vector3.zero;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }


    void Update()
    {
        
        if (character.isGrounded)
        {
            movimiento = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movimiento = transform.TransformDirection(movimiento) * Run;
            }
            else
            {
                movimiento = transform.TransformDirection(movimiento) * Walk;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                movimiento.y = Jump;
            }
        }

        movimiento.y -= Gravity * Time.deltaTime;
        character.Move(movimiento * Time.deltaTime);

    }


}
