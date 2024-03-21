using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    public float angularSpeed;
    float xAngle;
    void Update()
    {
        float vInput = Input.GetAxis("Horizontal");
        xAngle += angularSpeed * vInput* Time.deltaTime;
        transform.rotation = Quaternion.Euler(xAngle, 0 , 0);
    }
}
