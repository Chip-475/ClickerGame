using UnityEngine;

public class expUPButton : MonoBehaviour
{
    public expUPManager manager;
    public AudioClip upgradeSFX;
    public void expUPclick()
    {
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        int cost = manager.expUPcost;
        if (data.money < cost&&manager.IsMaxLevel)
        {
            return;
        }
        clicker.clickExp+=10;
        data.expUPlvl++;
        data.money -= cost;
    }
}
