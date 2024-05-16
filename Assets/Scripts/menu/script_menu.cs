using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_menu : MonoBehaviour
{
    
    public void iniciarJuego(string nombreScena){
        SceneManager.LoadScene(nombreScena);
    }

    public void salir(){
        Application.Quit();
        Debug.Log("Aqui se cierra el juego");
    }
}
