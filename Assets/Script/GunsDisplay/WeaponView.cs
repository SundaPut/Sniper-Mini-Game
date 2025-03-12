using UnityEngine;

public class WeaponView : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float autoRotateSpeed = 30f;
    private float rotationY = 0f;

    void Update()
    {
        RotateWeapon();
    }

    private void RotateWeapon()
    {
        // Simpan rotasi X dan Z
        float savedXRotation = transform.localRotation.eulerAngles.x;
        float savedZRotation = transform.localRotation.eulerAngles.z;

        if (Input.GetMouseButton(0))
        {
            // Manual rotation
            float mouseX = Input.GetAxis("Mouse X");
            rotationY += mouseX * rotationSpeed * Time.deltaTime;
            rotationY = Mathf.Repeat(rotationY, 360f); 
        }
        else
        {
            // Automatic rotation
            rotationY += autoRotateSpeed * Time.deltaTime; 
            rotationY = Mathf.Repeat(rotationY, 360f);
        }

        transform.localRotation = Quaternion.Euler(savedXRotation, rotationY, savedZRotation);
    }
}