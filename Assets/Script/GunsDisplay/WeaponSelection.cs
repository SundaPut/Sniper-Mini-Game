using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] gunModel;

    private void Awake()
    {
        ChooseWeapon(SaveManager.Instance.currentWeapon);
    }

    private void ChooseWeapon(int index)
    {
        foreach (GameObject gun in gunModel)
        {
            gun.SetActive(false);
        }

        if (index >= 0 && index < gunModel.Length)
        {
            gunModel[index].SetActive(true);
        }
    }
}