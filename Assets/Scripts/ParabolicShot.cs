using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicShot
{
    public static Vector3 Position(float time, Vector3 initialPosition, Vector3 initialVelocity)
    {
        Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
        return 0.5f * gravity * Mathf.Pow(time, 2) + initialVelocity * time + initialPosition;
    }
    public static Vector3 Velocity(float time, Vector3 initialPosition, Vector3 initialVelocity)
    {
        Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
        return gravity * time + initialVelocity;
    }
    public static float FlyingTime(Vector3 initialVelocity, Vector3 initialPosition)
    {
        float g = 9.81f;
        float y0= initialPosition.y;
        float v0y = initialVelocity.y;
        float result = (v0y + Mathf.Sqrt(Mathf.Pow(v0y, 2) + 2 * g * y0)) / g;
        return result;
    }
}
