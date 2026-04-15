using UnityEngine;

public class cannonFireRateUPButton : MonoBehaviour
{
    public cannonFireRateUPManager manager;

    public void UpgradeFireRate()
    {
        if (manager == null || manager.IsMaxLevel)
        {
            return;
        }

        int cost = manager.CurrentCost;
        if (data.money >= cost)
        {
            return;
        }
        data.money -= cost;
        data.cannonFireRatelvl++;
    }
}