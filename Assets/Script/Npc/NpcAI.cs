using System.Collections;
using UnityEngine;

public class NpcAI : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 2f;
    public float shotSpeedReduction = 0.5f;
    public float reductionDuration = 2f;

    private float originalSpeed;
    private bool isMoving = true;

    private void Start()
    {
        originalSpeed = speed;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        if (targetPoint == null) return;

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    }

    public void HitByShot()
    {
        if (isMoving)
        {
            StartCoroutine(ApplySpeedReduction());
        }
    }

    private IEnumerator ApplySpeedReduction()
    {
        speed *= shotSpeedReduction;
        yield return new WaitForSeconds(reductionDuration);
        speed = originalSpeed;
    }
}
