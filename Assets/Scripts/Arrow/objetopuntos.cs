using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objetopuntos : MonoBehaviour
{
    public GameObject Objpuntos;
    public float puntosqda;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Objpuntos.GetComponent<Puntos>().puntos += puntosqda;
            Destroy(gameObject);

            
        }
    }
}
