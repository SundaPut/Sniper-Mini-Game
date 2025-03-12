using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float startingHealth = 100f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject takeDamage;
    [SerializeField] private GameObject die;
    public float currentHealth { get; private set; }
    public bool IsDead { get; private set; }

    void Awake()
    {
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth;
        IsDead = false;
        UpdateHealthSlider();
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        UpdateHealthSlider();

        if (currentHealth > 0)
        {
            StartCoroutine(DamageEffect());
        }
        else
        {
            IsDead = true;
            die.SetActive(true);
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
            healthBar.value = currentHealth;
        }
    }
    private IEnumerator DamageEffect()
    {
        takeDamage.SetActive(true);
        yield return new WaitForSeconds(1);
        takeDamage.SetActive(false);
    }
}
