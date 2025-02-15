using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private HealthHandler healthHandler;

    private void Start()
    {
        healthHandler = GetComponent<HealthHandler>();
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
            }
        }
    }
}