using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class KinematicArrow : MonoBehaviour
{
    public Vector3 P0, V0;
    public bool fired;
    public Transform shootPoint;
    float time;
    void Start()
    {
        fired = false;
        GetComponent<TrailRenderer>().Clear();
        GetComponent<TrailRenderer>().emitting = false;
    }
    void Update()
    {
        if (fired)
        {
            time += Time.deltaTime;
            transform.position = ArrowPosition();
            transform.forward = ArrowVelocity();
        }
        else
        {
            transform.position = shootPoint.position;
            transform.rotation = shootPoint.rotation;
        }
    }

    Vector3 ArrowPosition()
    {
        Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
        return 0.5f * gravity *time * time + V0 * time + P0;
    }

    Vector3 ArrowVelocity()
    {
        Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
        return gravity * time + V0;
    }
}
