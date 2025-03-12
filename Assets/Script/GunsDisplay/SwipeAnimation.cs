using UnityEngine;

public class SwipeAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;

    private Vector3 initialPosition;

    public void Awake()
    {
        initialPosition = transform.position;
    }

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 1f);
    }

    public void OnDisable()
    {
            transform.position = initialPosition;
    }
}