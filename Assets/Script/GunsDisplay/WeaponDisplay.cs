using Mono.Cecil;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    [Header("Gun Name")]
    [SerializeField] private TMP_Text gunName;

    [Header("Gun Stats")]
    [SerializeField] private Transform damage;
    [SerializeField] private Transform range;
    [SerializeField] private Transform fireRate;

    [Header("Gun Holder")]
    [SerializeField] private Transform gunHolder;

    public void DisplayWeapon(Weapon weapon)
    {
        gunName.text = weapon.gunName;

        //damage
        for (int i = 0; i < damage.childCount; i++)
            damage.GetChild(i).gameObject.SetActive(i < weapon.damage);

        //range
        for (int i = 0; i < range.childCount; i++)
            range.GetChild(i).gameObject.SetActive(i < weapon.range);

        //fire rate
        for (int i = 0; i < fireRate.childCount; i++)
            fireRate.GetChild(i).gameObject.SetActive(i < weapon.fireRate);


        if (gunHolder.childCount > 0) Destroy(gunHolder.GetChild(0).gameObject);

        GameObject newGun = Instantiate(weapon.gunModel);
        newGun.transform.SetParent(gunHolder, false);
        newGun.AddComponent<WeaponView>();
    }
}
