using System.Collections;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public Camera mainCamera;
    public float mouseSensitivity = 100f;
    public float normalFov;

    [Header("Cursor Settings")]
    public bool lockCursor = true;
    public bool hideCursor = true;

    private float xRotation = 0f;

    void Start()
    {
        normalFov = mainCamera.fieldOfView;
    }

    public void PlayerLook(Camera camera)
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 50f);

        // Rotasi kamera
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void SetFieldOfView(float fov)
    {
        mainCamera.fieldOfView = fov;
    }

    public float GetNormalFov()
    {
        return normalFov;
    }
}
