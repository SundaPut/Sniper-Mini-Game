using UnityEngine;

public class WeaponsModel : MonoBehaviour
{
    [SerializeField] private GameObject[] gunModel;

    // Atur posisi dan rotasi
    [SerializeField] private Vector3[] spawnPosition;
    [SerializeField] private Vector3[] spawnRotation;

    private void Awake()
    {
        ChooseWeapon(SaveManager.Instance.currentWeapon);
    }

    private void ChooseWeapon(int index)
    {
        if (index >= 0 && index < gunModel.Length)
        {
            Quaternion rotation = Quaternion.Euler(spawnRotation[index]);
            GameObject weaponInstance = Instantiate(gunModel[index], spawnPosition[index], rotation, transform);
        }
    }
}