using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.name); // Mensaje de depuración

        if (other.CompareTag("VidaExtra"))
        {
            Debug.Log("Vida extra recogida");  // Mensaje de depuración
            GameManager.AumentarVidas();
            Destroy(other.gameObject);
        }
    }
}
