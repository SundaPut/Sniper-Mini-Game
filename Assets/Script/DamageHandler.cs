using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float damage = 10f;

    public void SetDamage(float damageAmount)
    {
        damage = damageAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthHandler damageHandler = other.gameObject.GetComponent<HealthHandler>();
            if (damageHandler != null)
            {
                damageHandler.TakeDamage(damage);
                Destroy(gameObject); // Hapus proyektil setelah memberikan damage
            }
        }
    }
}
