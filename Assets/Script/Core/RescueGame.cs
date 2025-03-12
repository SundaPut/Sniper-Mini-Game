using System.Collections;
using UnityEngine;
using TMPro;

public class RescueGame : MonoBehaviour
{
    [Header("Objective")]
    public GameObject npc;
    public Transform targetPoint;

    [Header("Time")]
    public float time = 60f;
    public TextMeshProUGUI timerText;

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

    private void UpdateTimer()
    {
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Max(0, Mathf.Ceil(timeRemaining)).ToString();

        if (timeRemaining <= 0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            VisibleCursor();
        }
    }

    private void CheckNPCLife()
    {
        if (npc == null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            VisibleCursor();
        }

        if (Vector3.Distance(npc.transform.position, targetPoint.position) < 0.1f)
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
