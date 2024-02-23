using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerStay(Collider other)
    {
        playerController.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.puedoSaltar = false;
    }
}