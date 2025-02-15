using UnityEngine;

public class ScopeHandler : MonoBehaviour
{
    [Header("Scope Settings")]
    public Transform weaponTransform; // Transform senjata yang akan diubah
    public Vector3 scopedPositionOffset; // Offset posisi senjata saat scope aktif
    public Vector3 originalPosition; // Posisi asli senjata

    private bool isScoped = false; // Status scope

    void Start()
    {
        // Simpan posisi asli senjata
        originalPosition = weaponTransform.localPosition;
    }

    public void ToggleScope()
    {
        isScoped = !isScoped; // Toggle status scope

        if (isScoped)
        {
            // Jika scope aktif, ubah posisi senjata
            weaponTransform.localPosition = originalPosition + scopedPositionOffset;
        }
        else
        {
            // Kembalikan posisi senjata ke posisi asli
            weaponTransform.localPosition = originalPosition;
        }
    }
}
