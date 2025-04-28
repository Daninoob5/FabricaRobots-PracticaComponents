using UnityEngine;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;


public class GeneradorController : MonoBehaviour
{
    //Public Atributes
    public Podio[] podios;
    public GameObject robotPlantilla;
    public bool activarGenerador;
    public int ratio = 5;
    public List<GameObject> robotsFabricados;
    //Private Atributes
    [SerializeField] private List<GameObject> piezasRobot = new List<GameObject>();
    private float contador;
    private GameObject robot;
    private GameObject boton;
    //Methods
    void Start()
    {
        contador = 0;
        piezasRobot.Clear();
        boton = gameObject.GetComponentInChildren<Botón>().gameObject;
        boton.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
    }
    void Update()
    {
        if (activarGenerador)
        {
            boton.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            contador += Time.deltaTime;
            if (contador > ratio)
            {
                CrearRobot();
                contador = 0;

            }
        }
        else
        {
            contador = 0;
            boton.GetComponent<Renderer>().material.SetColor("_EmissionColor",Color.red);
        }
    }
    private void CrearRobot()
    {
        robot = Instantiate(robotPlantilla, transform.position + new Vector3(0, 0.75f, 0), Quaternion.Euler(0,90,0));
        foreach (Parte parte in robot.GetComponentsInChildren<Parte>())
        {
            piezasRobot.Add(parte.gameObject);
        }
        for (int i = 0; i < piezasRobot.Count; i++)
        {
            int prob = Random.Range(0,2);
            switch(prob)
            {
                case 0:
                    piezasRobot[i].SetActive(false); break;
                case 1:
                    piezasRobot[i].SetActive(true);break;
            }
        }
        int probG = Random.Range(0,25);
        if (probG == 0)
        {
            foreach (Renderer renderer in robot.GetComponentsInChildren<Renderer>())
            {
                if (renderer.material.color != Color.black)
                {
                    renderer.material.color = Color.yellow;
                }
            }
        }
        robotsFabricados.Add(robot);
        robot.GetComponent<Robot>().controller = this;
        robot.GetComponent<Robot>().numeroFabrica = robotsFabricados.Count - 1;
        robot = null;
        piezasRobot.Clear();
    }
    public void moverAPodio(int numeroFabrica)
    {
        for (int i = 0;i < podios.Length; i++)
        {
            if (!podios[i].ocupado)
            {
                robotsFabricados[numeroFabrica].GetComponent<Transform>().position = podios[i].gameObject.GetComponent<Transform>().position + new Vector3(0,7,0);
                robotsFabricados[numeroFabrica].GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                break;
            }
        } 
    }
}
