using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    private GameObject player;
    public GameObject panelEsferas;
    public GameObject capsula;
    public bool misionAceptada;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        misionAceptada = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);
        }
    }

    public void MisionAceptada()
    {
        misionAceptada = true;
        capsula.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !misionAceptada)
        {
            panelEsferas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            panelEsferas.SetActive(false);
        }
    }
}