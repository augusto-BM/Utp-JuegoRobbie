using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisi�n detectada con: " + other.name); // Mensaje de depuraci�n

        if (other.CompareTag("VidaExtra"))
        {
            Debug.Log("Vida extra recogida");  // Mensaje de depuraci�n
            GameManager.AumentarVidas();
            Destroy(other.gameObject);
        }
    }
}
