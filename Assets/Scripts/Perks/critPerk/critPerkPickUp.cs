using UnityEngine;

public class critPerkPickUp : MonoBehaviour
{
    public void crituppickup()
    {
        if (data.PerkLimit > data.totalPerk)
        {
            data.critPerkAmount++;
            Destroy(gameObject);
        }
    }
}
