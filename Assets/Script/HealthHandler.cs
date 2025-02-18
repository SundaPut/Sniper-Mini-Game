using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private ScoreManager scoreManager;
    private PlayerHealth playerHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        scoreManager = FindFirstObjectByType<ScoreManager>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"{gameObject.name} took {amount} damage. Remaining health: {currentHealth}");

        if (currentHealth == 0 && CompareTag("Enemy"))
        {
            Die();
            IncreasePoint();
        }

        else if (currentHealth == 0 && CompareTag("Warga"))
        {
            Die();
            DecreasePoint();
            DecreaseHealthPlayer(amount);
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    void DecreasePoint()
    {
        scoreManager.DecreaseScore();
    }

    void IncreasePoint()
    {
        scoreManager.IncreaseScore();
    }

    void DecreaseHealthPlayer(float damage)
    {
        playerHealth.TakeDamage(damage);
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
