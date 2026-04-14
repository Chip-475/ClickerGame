using UnityEngine;

public class GoldMeteorPickUp : MonoBehaviour
{
    public void goldmeteorPickup()
    {
        if (data.PerkLimit > data.totalPerk)
        {
            data.goldMeteor++;
            //animationPH
            Destroy(gameObject);
        }
    }
}
