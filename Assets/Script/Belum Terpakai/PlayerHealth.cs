using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float startingHealth = 100f;
    [SerializeField] private Slider healthBar;
    public float currentHealth { get; private set; }
    public bool IsDead { get; private set; }

    void Awake()
    {
        currentHealth = startingHealth;
        IsDead = false;
        UpdateHealthSlider();
    }
    private void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        UpdateHealthSlider();

        if (currentHealth > 0)
        {

        }
        else
        {
            IsDead = true;
            Destroy(gameObject);
        }
    }

    public void AddHealth(float value)
    {
        if (IsDead) return;
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / startingHealth;
        }
    }
  }
