using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movimientos básicos
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 100f;
    public float x, y;

    // animación
    public Animator anim;

    //Cámaras
    public Camera camBack;
    public Camera camFront;

    //Salto
    public Rigidbody rb;
    public float fuerzaSalto = 80f;
    public bool puedoSaltar;
    public bool tocoSuelo;
    public bool saltee;

    // Agachado
    public float velocidadInicial;
    public float velocidadAgachado;

    // Golpeo Animación 
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10f;


    // Start is called before the first frame update
    void Start()
    {
        //Animación
        anim = GetComponent<Animator>();

        // Cámaras
        camBack.enabled = true;
        camFront.enabled = false;

        //Salto
        puedoSaltar = true;

        // Agachado
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;


        //Golpeo
        estoyAtacando = false;
        avanzoSolo = false;
    }

    // Update is called once per frame
    void Update()
    {
        // leemos cursores
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        // pasar pará,etros a animtor
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //Cambio cámara
        CambioCamara();

        // Saltar
        Saltar();

        // Agachado
        Agachado();


        //Golpeo
        Golpeo();
        Patada();
    }

    private void Patada()
    {
        if (Input.GetKeyDown(KeyCode.P) && puedoSaltar)
        {
            anim.SetTrigger("patada");
            estoyAtacando = true;
        }
    }

    private void Golpeo()
    {
        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyAtacando)
        {
            if (GameObject.Find("Player").GetComponent<OntenerPalo>().tenemosPalo)
            {
                anim.SetTrigger("espada");
            }
            else
            {
                anim.SetTrigger("golpeo");
            }

            estoyAtacando = true;
        }
    }

    private void Agachado()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("agachado", true);
            velocidadMovimiento = velocidadAgachado;
        }
        else
        {
            anim.SetBool("agachado", false);
            velocidadMovimiento = velocidadInicial;
        }
    }


    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            // Movemos
            transform.Rotate(0, x * Time.fixedDeltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.fixedDeltaTime * velocidadMovimiento);
        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }

    private void Saltar()
    {
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Salte", true);
                saltee = true;
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }

            anim.SetBool("tocoSuelo", true);
            tocoSuelo = true;
        }
        else
        {
            EstoyCayendo();
        }
    }

    private void EstoyCayendo()
    {
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("Salte", false);
        //anim
        tocoSuelo = false;
        saltee = false;
    }

    private void CambioCamara()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camBack.enabled = true;
            camFront.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camFront.enabled = true;
            camBack.enabled = false;
        }
    }

    public void DejoDeGolpear()
    {
        estoyAtacando = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}