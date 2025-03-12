using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    public Transform[] targetPoints;
    public float speed = 5.0f;
    private int currentTargetIndex = 0;
    private InputSystem_Actions input;
    void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {
        if (input.Player.Previous.triggered && currentTargetIndex > 0)
        {
            currentTargetIndex--;
            MoveToCurrentTarget();
        }

        if (input.Player.Next.triggered && currentTargetIndex < targetPoints.Length - 1)
        {
            currentTargetIndex++;
            MoveToCurrentTarget();
        }

    }

    void MoveToCurrentTarget()
    {
        StartCoroutine(MoveToPosition(targetPoints[currentTargetIndex].position));
    }

    System.Collections.IEnumerator MoveToPosition(Vector3 newPosition)
    {
        float journeyLength = Vector3.Distance(transform.position, newPosition);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, newPosition) > 0.1f)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(transform.position, newPosition, fractionOfJourney);
            yield return null;
        }

        transform.position = newPosition;
    }
    void OnDisable()
    {
        input.Disable(); 
    }
}