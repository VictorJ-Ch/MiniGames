using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win3Player : MonoBehaviour
{
    // Referencia al objeto de la pantalla de "¡Ganaste!" en la escena.
    public GameObject ganasteScreen;

    // Contador de jugadores en la plataforma.
    private int jugadoresEnPlataforma = 3;

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador entra en la plataforma, aumentamos el contador.
        if (other.CompareTag("Player"))
        {
            jugadoresEnPlataforma--;
            // Si es el último jugador, mostramos la pantalla de "¡Ganaste!".
            if (jugadoresEnPlataforma == 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

  
}
