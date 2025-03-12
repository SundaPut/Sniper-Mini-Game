using System.Drawing;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Enemy;
    public int health;

    public delegate void EnemyDeathHandler();
    public event EnemyDeathHandler OnEnemyDeath;

    private Transform[] targetPoints;

    private EliminationGame elimGame;
    private ScoreGame scrGame;
    private ObjectiveGame objectiveGame;

    private SpawnEnemy spawn;

    public void Start()
    {
        elimGame = FindFirstObjectByType<EliminationGame>();
        scrGame = FindFirstObjectByType<ScoreGame>();
        spawn = FindFirstObjectByType<SpawnEnemy>();
        objectiveGame = FindFirstObjectByType<ObjectiveGame>();

    }
    public void ReceiveDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);

            // panggil EnemyEliminated
            if (elimGame != null)  elimGame.EnemyEliminated();

            // panggil IncreaseScore
            if (scrGame != null) scrGame.IncreaseScore();

            //pangggil ObjectiveGame
            if (objectiveGame != null) objectiveGame.EnemyDefeated();

            OnEnemyDeath?.Invoke();
        }
    }
}