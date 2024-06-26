using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    public float initialSwingSpeed = 1f; // Velocidad inicial del péndulo
    private float swing; // Variable que controla el ángulo del péndulo
    public Transform fireBalls;
    private BezierCurve _bezierCurve;
    private float time;

    void Start()
    {
        _bezierCurve = GetComponent<BezierCurve>();
        swing = initialSwingSpeed;
    }

    void Update()
    {
        ControlPointsMovement();
        FireBallsMovement();
    }

    void FireBallsMovement()
    {
        for (int i = 0; i < fireBalls.childCount; i++)
        {
            float si = (float)i / (fireBalls.childCount - 1f);
            fireBalls.GetChild(i).position = _bezierCurve.Bezier(si);
        }
    }

    private void ControlPointsMovement()
    {
        float z1 = _bezierCurve.P[1].position.z;
        float z2 = _bezierCurve.P[2].position.z;
        _bezierCurve.P[1].position = CirclePath(5f, z1);
        _bezierCurve.P[2].position = CirclePath(5f, z2);
        time += Time.deltaTime;

        // Incrementar el ángulo del péndulo con el tiempo
        swing += Time.deltaTime * 0.1f; // Ajusta el factor multiplicador según la velocidad deseada
    }

    Vector3 CirclePath(float radius, float ZCoordinate)
    {
        float xCoordinate = radius * Mathf.Sin(swing * time);
        float yCoordinate = radius * Mathf.Cos(swing * time);
        return new Vector3(xCoordinate, yCoordinate, ZCoordinate);
    }
}
