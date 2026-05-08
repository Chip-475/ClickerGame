using UnityEngine;

public class baseClickPickUp : MonoBehaviour
{
    public void critUpPickup()
    {
        if (data.PerkLimit > data.totalPerk)
        {

            data.clickPerkAmount++;
            Destroy(gameObject);
        }
    }
}