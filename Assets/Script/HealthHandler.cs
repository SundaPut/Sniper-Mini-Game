using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private ScoreManager scoreManager;

    private void Start()
    {
        currentHealth = maxHealth;
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"{gameObject.name} took {amount} damage. Remaining health: {currentHealth}");

        if (currentHealth == 0)
        {
            scoreManager.IncreaseScore();

            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
