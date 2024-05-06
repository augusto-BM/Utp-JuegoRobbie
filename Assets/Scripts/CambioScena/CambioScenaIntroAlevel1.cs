
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CambioScenaIntroAlevel1 : MonoBehaviour
{
    public string nombreEscenaDelJuego; // Nombre de la escena del juego

    public VideoPlayer videoPlayer; // Referencia al VideoPlayer

    void Start()
    {
        videoPlayer.loopPointReached += CargarEscenaDelJuego; // Suscribe al evento del final del video
    }

    void CargarEscenaDelJuego(VideoPlayer vp)
    {
        SceneManager.LoadScene(nombreEscenaDelJuego); // Cambia a la escena del juego
    }
}

