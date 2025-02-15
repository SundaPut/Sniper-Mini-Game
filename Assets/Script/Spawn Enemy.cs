using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnArea;
    public float spawnInterval = 3f;
    public float moveSpeed = 2f;
    public float lifetime = 10f;
    public bool moveRight = true;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyMethod), 0f, spawnInterval);
    }

    private void Update()
    {
 
    }

    private void SpawnEnemyMethod()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyMove enemyMove = enemy.GetComponent<EnemyMove>();
        enemyMove.Initialize(moveSpeed, moveRight);
        enemyMove.lifetime = lifetime; // Set lifetime untuk musuh
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2);
        return new Vector3(x, spawnArea.position.y, spawnArea.position.z);
    }
}