using UnityEngine;

public class cannonDepotUPButton : MonoBehaviour
{
    public cannonDepotUPManager manager;
    public void UpgradeDepot()
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
        data.cannonDepotlvl++;
        manager.RefillNewCapacity();
    }
}
