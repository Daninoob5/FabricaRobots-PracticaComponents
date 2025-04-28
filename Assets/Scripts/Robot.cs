using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GeneradorController controller;
    public bool guardar;
    public bool eliminar;
    [NonSerialized] public int numeroFabrica;
    void Start()
    {
        guardar = false;
        eliminar = false;
    }
    void Update()
    {
        if (guardar)
        {
            controller.moverAPodio(numeroFabrica);
            guardar = false;
        }
        if(eliminar)
        {
            transform.position = new Vector3(-20,20,-20);
            eliminar = false;
        }
    }
}
