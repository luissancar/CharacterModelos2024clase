using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicaObjetivos : MonoBehaviour
{
    private int numDeObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonDeMision;

    

    public void InicializarEsferas()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Esferas restantes " + numDeObjetivos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "objetivo")
        {
            Destroy(other.transform.parent.gameObject);
            numDeObjetivos--;
            textoMision.text = "Esferas restantes " + numDeObjetivos;
            if (numDeObjetivos <= 0)
            {
                textoMision.text = "Objetivo cumplido";
                botonDeMision.SetActive(true);
            }
        }
    }
}