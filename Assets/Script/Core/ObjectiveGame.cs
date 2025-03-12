using System.Collections;
using UnityEngine;
using TMPro;

public class ObjectiveGame : MonoBehaviour
{
    [Header("Objective")]
    public GameObject boss;
    public Transform targetPoint;

    [Header("Time")]
    public float time = 60f;
    public TextMeshProUGUI timerText;

    [Header("UI")]
    public GameObject winPanel;
    public GameObject losePanel;

    private float timeRemaining;
    private int defeatedEnemies = 0;
    private const int totalEnemies = 5;

    private void Start()
    {
        timeRemaining = time;
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        StartCoroutine(GameTimer());
        Time.timeScale = 1;
    }

    private void Update()
    {
        ChechkCarsEnemy();
    }
    public void EnemyDefeated()
    {
        defeatedEnemies++;

        if (defeatedEnemies >= totalEnemies)
        {
            Destroy(boss);
        }
    }

    private void ChechkCarsEnemy()
    {
        if (boss == null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
            VisibleCursor();
        }

        if (Vector3.Distance(boss.transform.position, targetPoint.position) < 0.1f)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            VisibleCursor();
        }
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
