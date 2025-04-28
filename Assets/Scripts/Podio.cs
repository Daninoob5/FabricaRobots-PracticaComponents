using System;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Podio : MonoBehaviour
{
    public bool ocupado;
    GameObject usuario;
    void Start()
    {
        ocupado = false;
    }
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        ocupado = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        ocupado = false;
    }
}
