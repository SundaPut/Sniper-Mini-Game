using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Shoting : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint;

    [Header("Shooting Settings")]
    public float shootForce = 700f;
    public float destroyDelay = 5f;
    public float attackCooldown = 1f; 
    public string projectileTag = "Projectile";
    public float damage;
    private float cooldownTimer;

    [Header("Prefab Settings")]
    public bool addRigidbody = true;
    public float spawnDelay = 0.5f;

    [Header("Shooting Events")]
    public UnityEvent OnShooting;

    private Animator anim;
    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        cooldownTimer = attackCooldown;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime; // Tambahkan waktu ke cooldown timer

        if (cooldownTimer >= attackCooldown)
        {
            if (input.Player.Attack.triggered)
            {
                StartCoroutine(Shoot());
                anim.SetTrigger("FireUnScope");
                cooldownTimer = 0f; // Panggil coroutine
            }
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(spawnDelay);

        // Cek apakah prefab dan titik tembak sudah diatur
        if (projectilePrefab == null || shootPoint == null)
        {
            Debug.LogWarning("Projectile prefab or shoot point is not assigned.");
            yield break;
        }

        // Membuat instance dari prefab
        GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        projectileInstance.tag = projectileTag;

        if (addRigidbody)
        {
            Rigidbody rb = projectileInstance.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(shootPoint.forward * shootForce);
        }

        yield return new WaitForSeconds(spawnDelay);

        // Menggunakan raycasting untuk mendeteksi tabrakan
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(projectileInstance, destroyDelay);
            }

            // Panggil event menembak
            OnShooting.Invoke();
        }
    }
    void OnDisable()
    {
        input.Disable();
    }
}