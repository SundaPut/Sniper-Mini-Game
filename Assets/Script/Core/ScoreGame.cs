using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Rendering;

public class ScoreGame : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject win;
    public GameObject lose;

    public int target;
    public float time = 120;
    private int score = 0;

    private void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);

        Time.timeScale = 1;
        UpdateScoreText();
        StartCoroutine(GameTimer());
    }

    public void Update()
    {
        if (time == 0 && score * 10 >= target)
        {
            win.SetActive(true);

            Time.timeScale = 0;
            VisibleCursor();
        }
        else if (time == 0 && score * 10 < target)
        {
            lose.SetActive(true);

            Time.timeScale = 0;
            VisibleCursor();
        }
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    public void DecreaseScore()
    {
        score--;
        UpdateScoreText();

    }

    private void UpdateScoreText()
    {
        scoreText.text = " " + (score * 10);
    }

    private void VisibleCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator GameTimer()
    {
        while (time >= 0)
        {
            // Hitung menit dan detik
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Tunggu satu detik
            yield return new WaitForSeconds(1f);
            time--; // Kurangi waktu
        }
    }
}
