using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Scriptable Objects/Gun")]
public class Weapon : ScriptableObject
{
    [Header("Gun Name")]
    public string gunName;

    [Header("Gun Stats")]
    [Range(1,6)] public int damage;
    [Range(1,6)] public int range;
    [Range(1,6)] public int fireRate;

    [Header("Gun Model")]
    public GameObject gunModel;
}
