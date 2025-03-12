using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform shootPoint;
    public float shootingRate = 1f;
    public int damage = 1;
    private float nextShootTime;

    public bool canShoot = false;

    private void Update()
    {
        if (canShoot && Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            nextShootTime = Time.time + shootingRate;
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
    }

    public void ShootAtPlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = (player.position - shootPoint.position).normalized;

            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, directionToPlayer, out hit, 400))
            {
                Debug.DrawRay(shootPoint.position, directionToPlayer * hit.distance, Color.yellow);

                PlayerHealth playerHealth = hit.transform.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }

                NpcHealth npcHealth = hit.transform.GetComponent<NpcHealth>();

                if (npcHealth != null)
                {
                    npcHealth.ReceiveDamage(damage);
                }
            }
        }
    }
}
