using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class RollRunnerController : MonoBehaviour
{
    public float angularSpeed, radius;
    float xPosition, angle;
    bool isPlaying = true;
    void Start()
    {
        xPosition = transform.localPosition.x;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void Update()
    {
        if(isPlaying)
        {
            PlayerMovement();
        }
    }
    void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical-P1");
        angle += angularSpeed * verticalInput * Time.deltaTime;
        transform.localPosition = AngularPosition();
        Vector3 up = AngularPosition();
        up.x = 0;
        Vector3 forward = Vector3.zero;
        if(verticalInput >= 0) {forward = Vector3.Cross(Vector3.right, up);}
        else{forward = -Vector3.Cross(Vector3.right, up);}
        transform.localRotation = Quaternion.LookRotation(forward, up);
    }
    Vector3 AngularPosition()
    {
        float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(xPosition, y, z);
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("limit"))
        {
            Debug.Log("Outside");
            Vector3 radialoPosition = AngularPosition();
            radialoPosition.x = 0;
            Vector3 slipDirection = Vector3.zero;
            if(transform.position.z <= 0){slipDirection = Vector3.Cross(radialoPosition, Vector3.right).normalized;}
            else{slipDirection = Vector3.Cross(radialoPosition, -Vector3.right).normalized;}
            transform.parent =  null;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(5 * slipDirection, ForceMode. Impulse);
            isPlaying = false;
        }
    }
}