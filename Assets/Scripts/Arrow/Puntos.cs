using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Puntos : MonoBehaviour
{
    public float puntos;
    public TextMeshProUGUI textopuntos;

    private void Update()
    {
        textopuntos.text = "Puntos " + puntos.ToString();
    }

}
