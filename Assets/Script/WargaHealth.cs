using UnityEngine;

public class WargaHealth : MonoBehaviour
{
    private HealthHandler healthHandler;
    private PlayerHealth playerHealth;

    private void Start()
    {
        healthHandler = GetComponent<HealthHandler>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        if (healthHandler == null)
        {
            Debug.LogError("HealthHandler component not found on the enemy.");
        }
    }

    public void ReceiveDamage(float damageAmount)
    {
        if (healthHandler != null)
        {
            healthHandler.TakeDamage(damageAmount);
            if (healthHandler.GetCurrentHealth() <= 0)
            {
                Destroy(gameObject);
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
