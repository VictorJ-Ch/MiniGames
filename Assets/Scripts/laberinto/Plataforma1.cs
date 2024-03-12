using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plataforma : MonoBehaviour
{

    public string WinPl2;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            // Cambia a la nueva escena
            SceneManager.LoadScene(2);
        }
    }
}