using UnityEngine;

public class cannonDepotUPButton : MonoBehaviour
{
    public cannonDepotUPManager manager;
    public AudioClip upgradeSFX;
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
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        data.money -= cost;
        data.cannonDepotlvl++;
        manager.RefillNewCapacity();
    }
}
