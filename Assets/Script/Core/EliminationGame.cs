using System.Collections;
using UnityEngine;
using TMPro;

public class EliminationGame : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI enemyTarget;
    public GameObject winText;
    public GameObject Clear;

    [Header("Count")]
    public int targetEnemies = 10;
    public int eliminatedEnemies = 0;

    void Start()
    {
        Clear.SetActive(false);
        Time.timeScale = 1;
        enemyTarget.text = "Target: " + targetEnemies.ToString();
        winText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckWinCondition();
    }

    public void EnemyEliminated()
    {
        eliminatedEnemies++;
    }

    private void CheckWinCondition()
    {
        if (eliminatedEnemies >= targetEnemies)
        {
            WinGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void WinGame()
    {        
        winText.gameObject.SetActive(true);
        Clear.SetActive(true);
        Time.timeScale = 0;
    }
}
