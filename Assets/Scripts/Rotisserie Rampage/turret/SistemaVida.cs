﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaVida : MonoBehaviour
{
    public float maxVida = 100.0f;
    public float actualVida;

    public bool inmortal = false;
    public float tiempoInmortal = 1.0f;

    public GameObject explosionPrefab;

    private void Start()
    {
        actualVida = maxVida;
    }

    private void Update()
    {
        if (actualVida > maxVida)
            actualVida = maxVida;

        if (actualVida <= 0)
        {
            Muerte();
        }
    }

    public void QuitarVida(float daño) //damage
    {
        if (inmortal) return;

        actualVida -= daño;
        StartCoroutine(TiempoInmortal());
    }

    public void DarVida(float vida)
    {
        actualVida += vida;
    }

    public void Muerte()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        ChangeScene(); // Llama a la función para cambiar de escena
        Destroy(this.gameObject);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Game9");
    }

    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(tiempoInmortal);
        inmortal = false;
    }
}
