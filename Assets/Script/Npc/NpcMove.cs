using UnityEngine;

public class NpcMove : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 2f;

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (targetPoint == null) return;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    }
}
