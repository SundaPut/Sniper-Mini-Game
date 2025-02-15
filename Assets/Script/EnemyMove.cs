using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float moveSpeed;
    private bool moveForward;
    public float lifetime = 10f;

    public void Initialize(float speed, bool direction)
    {
        moveSpeed = speed;
        moveForward = direction;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the enemy left or right
        Vector3 movement = moveForward ? Vector3.forward : Vector3.back;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}