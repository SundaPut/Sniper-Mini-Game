using UnityEngine;

public class NpcHealth : MonoBehaviour
{
    public GameObject npc;
    public int health = 1;

    public void ReceiveDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
