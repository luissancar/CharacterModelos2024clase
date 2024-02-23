using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEsferas : MonoBehaviour
{
    public GameObject[] esferas;

    public void ActivarEsfera()
    {
        for (int i = 0; i < esferas.Length; i++)
        {
            esferas[i].SetActive(true);
        }
    }

}
