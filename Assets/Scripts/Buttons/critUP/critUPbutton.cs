using UnityEngine;

public class critUPbutton : MonoBehaviour
{
    public critUPmanager manager;
    public AudioClip upgradeSFX;
    public void critUPclick()
    {
        int cost = manager.critUPcost;
        if (data.money < cost||manager.IsMaxLevel)
        {
            return;
        }
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        data.critUPlvl++;
        data.money -= cost;
    }
}
