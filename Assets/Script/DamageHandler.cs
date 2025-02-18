using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float damage = 10f;
    public string[] validTags;

    public void SetDamage(float damageAmount)
    {
        damage = damageAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in validTags)
        {
            if (other.gameObject.CompareTag(tag))
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
}
