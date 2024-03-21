using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Obtener el componente Audio Source
        audioSource = GetComponent<AudioSource>();
        // Desactivar la reproducción automática
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reproducir el clip de audio cuando colisiona con otro objeto
        audioSource.Play();
    }
}

