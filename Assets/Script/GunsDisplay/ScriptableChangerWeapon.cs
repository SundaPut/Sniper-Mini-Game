using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class ScriptableChangerWeapon : MonoBehaviour
{
    [Header("Scriptable Object Script")]
    [SerializeField] private ScriptableObject[] scriptableObjects;

    [Header("Display Script")]
    [SerializeField] private WeaponDisplay weaponDisplays;

    private int currentIndexWeapon;

    public void Start()
    {
        currentIndexWeapon = SaveManager.Instance.currentWeapon;
        ChangeScriptableObject(0);
    }

    public void ChangeScriptableObject(int _change)
    {
        // Weapon
        currentIndexWeapon += _change;
        if(currentIndexWeapon < 0) currentIndexWeapon = scriptableObjects.Length - 1;
        else if (currentIndexWeapon > scriptableObjects.Length - 1) currentIndexWeapon = 0;

        if (weaponDisplays != null)
        {
            weaponDisplays.DisplayWeapon((Weapon) scriptableObjects[currentIndexWeapon]);
        }


        SaveManager.Instance.currentWeapon = currentIndexWeapon;
        SaveManager.Instance.Save();
    }

}
