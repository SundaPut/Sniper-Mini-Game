using System.Collections;
using UnityEngine;
using TMPro;

public class SaveNpcGame : MonoBehaviour
{
    [Header("Object")]
    public GameObject npc;

    [Header("Time")]
    public float time = 60f;
    public TextMeshProUGUI timerText;

    [Header("Count")]
    public TextMeshProUGUI enemyTarget;
    public int targetEnemies = 10;
    public int eliminatedEnemies = 0;

    [Header("UI")]
    public GameObject winPanel;
    public GameObject losePanel;

    private float timeRemaining;

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
        CheckNPCLife();
    }

    private void CheckNPCLife()
    {
        if (npc == null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            VisibleCursor();
        }

        if (eliminatedEnemies == targetEnemies && npc != null)
        {
            winPanel.SetActive(true);
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

            yield return new WaitForSeconds(1f);
            time--;
        }
    }
}
