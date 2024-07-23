using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_correr : MonoBehaviour
{
    // Variables para controlar la velocidad de movimiento y correr
    public float velocidadMovimiento = 5f;
    public float velocidadCorrer = 10f;

    // Variable para el Rigidbody2D del personaje
    private Rigidbody2D rb;

    // Variable para el Animator del personaje
    private Animator anim;

    // Variable para controlar la dirección del personaje
    private int direccion = -1; // -1 para izquierda, 1 para derecha

    // Start is called before the first frame update
    void Start()
    {
        // Obtener los componentes Rigidbody2D y Animator del personaje
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la velocidad en función de si el personaje está corriendo o no
        float velocidadActual = velocidadMovimiento; // No consideramos la velocidad de correr

        // Mover el personaje automáticamente en el eje X de izquierda a derecha
        rb.velocity = new Vector2(velocidadActual * direccion, rb.velocity.y);

        // Actualizar el parámetro "Velocidad" del Animator para cambiar las animaciones
        if (anim != null)
        {
            anim.SetFloat("Velocidad", Mathf.Abs(rb.velocity.x));
        }
    }

    // Método para cambiar la dirección del personaje
    public void CambiarDireccion()
    {
        direccion *= -1; // Cambiar la dirección multiplicando por -1

        // Obtener la escala actual del objeto
        Vector3 escala = transform.localScale;

        // Invertir la escala en el eje X para reflejar el cambio de dirección
        escala.x *= -1;

        // Aplicar la dirección a la escala en el eje X
        transform.localScale = escala;
    }

    // Método que se llama cuando el personaje colisiona con un trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Traps"))
        {
            CambiarDireccion(); // Cambiar la dirección del personaje
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Ejecutar la animación de festejar
            if (anim != null)
            {
                anim.SetTrigger("Festejar");
            }
        }
    }
}
