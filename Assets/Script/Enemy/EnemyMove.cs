using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    public float stoppingDistance = 0.5f;
    public float shootDelay = 1f; // Delay antara tembakan
    private int currentPointIndex = 0;
    private EnemyAI enemy;
    private bool isMoving = true;

    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if (isMoving)
        {
            Patrol();
        }

        if (enemy.canShoot)
        {
            StopPatrol();
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < stoppingDistance)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            StartCoroutine(ShootPlayer());
        }
    }

    public void MoveToPoint(Transform targetPoint)
    {
        transform.position = targetPoint.position;
        isMoving = false; // Menghentikan gerakan setelah tiba di titik
    }

    private IEnumerator ShootPlayer()
    {
        while (enemy.canShoot)
        {
            // Logika untuk menembaki pemain
            Debug.Log("Shooting at player!");
            yield return new WaitForSeconds(shootDelay); // Tunggu sebelum menembak lagi
        }
    }

    public void StopPatrol()
    {
        speed = 0f;
        isMoving = false; // Menghentikan gerakan
    }
}