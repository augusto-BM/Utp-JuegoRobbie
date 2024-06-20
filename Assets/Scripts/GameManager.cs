﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    static GameManager current;

    public float deathSequenceDuration = 1.5f;
    List<Orb> orbs;
    Door lockedDoor;
    SceneFader sceneFader;

    int numberOfDeaths;
    float totalGameTime;
    bool isGameOver;

    static int playerLives = 5;

    void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }

        current = this;
        orbs = new List<Orb>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isGameOver)
            return;

        totalGameTime += Time.deltaTime;
        UIManager.UpdateTimeUI(totalGameTime);
    }

    public static bool IsGameOver()
    {
        if (current == null)
            return false;

        return current.isGameOver;
    }

    public static void RegisterSceneFader(SceneFader fader)
    {
        if (current == null)
            return;

        current.sceneFader = fader;
    }

    public static void RegisterDoor(Door door)
    {
        if (current == null)
            return;

        current.lockedDoor = door;
    }

    public static void RegisterOrb(Orb orb)
    {
        if (current == null)
            return;

        if (!current.orbs.Contains(orb))
            current.orbs.Add(orb);

        UIManager.UpdateOrbUI(current.orbs.Count);
    }

    public static void PlayerGrabbedOrb(Orb orb)
    {
        if (current == null)
            return;

        if (!current.orbs.Contains(orb))
            return;

        current.orbs.Remove(orb);

        if (current.orbs.Count == 0)
            current.lockedDoor.Open();

        UIManager.UpdateOrbUI(current.orbs.Count);
    }

    public static void PlayerDied()
    {
        if (current == null)
            return;

        current.numberOfDeaths++;
        UIManager.UpdateDeathUI(current.numberOfDeaths);

        playerLives--;
        UIManager.UpdateLifeUI(playerLives);

        if (playerLives > 0)
        {
            if (current.sceneFader != null)
                current.sceneFader.FadeSceneOut();

            current.Invoke("RestartScene", current.deathSequenceDuration);
        }
        else
        {
            current.GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        UIManager.DisplayPerdioJuegoText();
        Debug.Log("¡Has perdido el juego!");
    }

    public static void PlayerWon()
    {
        if (current == null)
            return;

        current.isGameOver = true;
        UIManager.DisplayGameOverText();
        AudioManager.PlayWonAudio();

        string nextSceneName = "Level02";
        SceneManager.LoadScene(nextSceneName);
    }

    void RestartScene()
    {
        orbs.Clear();
        AudioManager.PlaySceneRestartAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void AumentarVidas()
    {
        // Si no hay un GameManager actual, salir
        if (current == null)
            return;

        // Aumentar el número de vidas del jugador
        playerLives++;
        UIManager.UpdateLifeUI(playerLives);  // Actualizar la UI de vidas

        Debug.Log("Vidas aumentadas: " + playerLives);  // Mensaje de depuración
    }

}
