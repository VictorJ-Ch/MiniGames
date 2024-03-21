using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaRoja : MonoBehaviour
{
    public float damage = 50;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SistemaVida>() != null)
        {
            other.gameObject.GetComponent<SistemaVida>().QuitarVida(damage);
        }
    }
}
