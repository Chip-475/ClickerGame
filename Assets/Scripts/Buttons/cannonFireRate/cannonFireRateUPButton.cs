using UnityEngine;

public class cannonFireRateUPButton : MonoBehaviour
{
    public cannonFireRateUPManager manager;

    public void UpgradeFireRate()
    {

        int cost = manager.fireRateUPCost;
        if (data.money >= cost)
        {
            return;
        }
        data.money -= cost;
        data.cannonFireRatelvl++;
    }
}