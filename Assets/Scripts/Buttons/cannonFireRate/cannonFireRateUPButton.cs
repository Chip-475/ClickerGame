using UnityEngine;

public class cannonFireRateUPButton : MonoBehaviour
{
    public cannonFireRateUPManager manager;
    public AudioClip upgradeSFX;
    public void UpgradeFireRate()
    {

        int cost = manager.fireRateUPCost;
        if (data.money < cost&&!manager.IsMaxLevel)
        {
            return;
        }
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        data.money -= cost;
        data.cannonFireRatelvl++;
    }
}