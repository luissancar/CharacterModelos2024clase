using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class OntenerPalo : MonoBehaviour
{
    public GameObject paloScene;
    public GameObject paloMano;
    public bool tenemosPalo;


    private void Start()
    {
        tenemosPalo = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && tenemosPalo)
        {
            Vector3 posicion = gameObject.transform.position;
            paloScene.transform.position = new Vector3(posicion.x + 2, posicion.y, posicion.z);
            paloMano.SetActive(false);
            paloScene.SetActive(true);
            tenemosPalo = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Palo")
        {
            paloMano.SetActive(true);
            paloScene.SetActive(false);
            tenemosPalo = true;
        }
    }
}