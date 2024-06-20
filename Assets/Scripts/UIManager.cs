using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    static UIManager current;

    public TextMeshProUGUI orbText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI perdiojuegoText;

    void Awake()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }

        current = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void UpdateOrbUI(int orbCount)
    {
        if (current == null)
            return;

        current.orbText.text = orbCount.ToString();
    }

    public static void UpdateTimeUI(float time)
    {
        if (current == null)
            return;

        int minutes = (int)(time / 60);
        float seconds = time % 60f;
        current.timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public static void UpdateDeathUI(int deathCount)
    {
        if (current == null)
            return;

        current.deathText.text = deathCount.ToString();
    }

    public static void UpdateLifeUI(int lifeCount)
    {
        if (current == null)
            return;

        current.lifeText.text = lifeCount.ToString();
    }

    public static void DisplayGameOverText()
    {
        if (current == null)
            return;

        current.StartCoroutine(current.ShowGameOverTextCoroutine());
    }

    private IEnumerator ShowGameOverTextCoroutine()
    {
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2f);
        gameOverText.enabled = false;
    }

    public static void DisplayPerdioJuegoText()
    {
        if (current == null)
            return;

        current.StartCoroutine(current.ShowPerdioJuegoTextCoroutine());
    }

    private IEnumerator ShowPerdioJuegoTextCoroutine()
    {
        perdiojuegoText.enabled = true;
        yield return new WaitForSeconds(2f);
        perdiojuegoText.enabled = false;
    }
}
