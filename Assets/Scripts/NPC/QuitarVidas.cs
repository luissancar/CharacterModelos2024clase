using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class QuitarVidas : MonoBehaviour
{
    public GameObject NPC;
    public Image barraVidas;

    private int vidasMax = 100;

    private float vidaActual;

   // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidasMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vidaActual -= 10;
            barraVidas.fillAmount = vidaActual / vidasMax;
            if (vidaActual <= 0)
            {
                Destroy(NPC,2f);
            }
        }
    }
}