using UnityEngine;

public class cannonDepotUPButton : MonoBehaviour
{
    public cannonDepotUPManager manager;
    public void UpgradeDepot()
    {
        if (manager.IsMaxLevel)
        {
            return;
        }

        int cost = manager.depotUpCost;
        if (data.money < cost)
        {
            return;
        }
        data.money -= cost;
        data.cannonDepotlvl++;
        manager.RefillNewCapacity();
    }
}
