using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Shoting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public Transform shootPoint;
    public GameObject hitPoint;

    [Header("Weapon Settings")]
    public Weapon[] weapons;
    public int currentWeaponIndex;

    [Header("Ammo Settings")]
    public int mag;
    public int ammo;
    public int magAmmo;

    [Header("UI Settings")]
    public TextMeshProUGUI magText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI noAmmoText;

    private int fireDelay;
    private bool isShooting;
    private Animator anim;
    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    private void Start()
    {
        currentWeaponIndex = SaveManager.Instance.currentWeapon;
        anim = GetComponent<Animator>();
        noAmmoText.gameObject.SetActive(false);
        fireDelay = 6 / weapons[currentWeaponIndex].fireRate;
        UpdateUI();
    }

    void Update()
    {
        if (input.Player.Attack.triggered && ammo > 0 && !isShooting)
        {
            isShooting = true;

            ammo--;
            UpdateUI();

            Shooting();
            anim.SetTrigger("FireUnScope");
            StartCoroutine(ShootingDelay());
        }
        
        if (ammo <= 0)
        {
            noAmmoText.gameObject.SetActive(true);
        }

        if (input.Player.Reload.triggered)
        {
            Reload();
        }
    }

    private void Reload()
    {
        if (mag > 0)
        {
            mag--;
            ammo = magAmmo;
            noAmmoText.gameObject.SetActive(false);
        }

        UpdateUI();
    }

    public void Shooting()
    {
        RaycastHit hit;
        bool hitEnemy = false;

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 400))
        {
            Debug.DrawRay(shootPoint.position, shootPoint.forward * hit.distance, Color.yellow);

            GameObject a = Instantiate(hitPoint, hit.point, Quaternion.identity);

            Destroy(a, 1);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.ReceiveDamage(weapons[currentWeaponIndex].damage);
                hitEnemy = true;
            }
        }

        if (!hitEnemy)
        {
            NotifyEnemies();
        }
    }

    private void NotifyEnemies()
    {
        EnemyAI[] enemies = UnityEngine.Object.FindObjectsByType<EnemyAI>(FindObjectsSortMode.None);
        foreach (EnemyAI enemy in enemies)
        {
            enemy.EnableShooting();
        }
    }

    private IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(fireDelay);
        isShooting = false; 
    }

    private void UpdateUI()
    {
        magText.text = mag.ToString();
        ammoText.text = ammo + "/" + magAmmo;
    }

    void OnDisable()
    {
        input.Disable();
    }
}