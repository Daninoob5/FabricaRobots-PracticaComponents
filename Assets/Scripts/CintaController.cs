using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CintaController : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {

        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            Vector3 direccionMundo = transform.TransformDirection(gameObject.transform.forward.normalized);
            Vector3 velocidadActual = rb.linearVelocity;
            Vector3 nuevaVelocidad = direccionMundo * 2;
            nuevaVelocidad.y = velocidadActual.y; 

            rb.linearVelocity = nuevaVelocidad;
            rb.freezeRotation = true;
        }

    }
}
