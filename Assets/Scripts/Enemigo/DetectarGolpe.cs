using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarGolpe : MonoBehaviour
{
    // player
    public GameObject player;

    // animación
    public Animator anim;
    public bool golpeado;
    public float distancia;
    
    
    //sonido
    private AudioSource sonido;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        sonido = GetComponent<AudioSource>();
        golpeado = false;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia < 4)
        {
            anim.SetBool("Cerca", true);
        }
        else
        {
            anim.SetBool("Cerca", false);
        }

        if (player != null)
            transform.LookAt(player.transform);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puno" && 
            player.GetComponent<PlayerController>().estoyAtacando &&
            !golpeado)
        {
            sonido.Play();
            anim.SetTrigger("Golpeado");
            golpeado = true;
        }
    }
}