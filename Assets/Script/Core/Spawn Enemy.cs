using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] patrolPoints;
    public float spawnInterval = 3f;
    public int maxEnemies = 5;
    public bool isMoving;

    private List<Transform> occupiedPoints = new List<Transform>();
    private int currentEnemyCount = 0;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyMethod), 0f, spawnInterval);
    }

    private void SpawnEnemyMethod()
    {
        Transform targetPoint = GetAvailablePatrolPoint();
        if (targetPoint == null)
        {
            return;
        }

        if (currentEnemyCount >= maxEnemies)
        {
            return;
        }

        GameObject enemy = Instantiate(enemyPrefab, targetPoint.position, Quaternion.identity);
        MoveToPoint(targetPoint);
        enemy.GetComponent<EnemyHealth>().OnEnemyDeath += () => ReleasePatrolPoint(targetPoint);
        currentEnemyCount++;
    }

    private Transform GetAvailablePatrolPoint()
    {
        foreach (Transform point in patrolPoints)
        {
            if (!occupiedPoints.Contains(point))
            {
                occupiedPoints.Add(point);
                return point; 
            }
        }
        return null;
    }

    public void MoveToPoint(Transform targetPoint)
    {
        transform.position = targetPoint.position;
        isMoving = false;
    }

    public void ReleasePatrolPoint(Transform point)
    {
        occupiedPoints.Remove(point);
        Debug.Log("Patrol point released: " + point.name);
    }
}