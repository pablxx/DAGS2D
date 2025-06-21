using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIU : MonoBehaviour
{
    public static ControlIU Instancia;
    [SerializeField]
    private GameObject panelGameOver;

    private void Awake()
    {
        if (Instancia != null)
            Destroy(gameObject);
        else
            Instancia = this;
    }

    public void ActivarPanelGameOver()
    {
        panelGameOver.SetActive(true);
    }
}
