using UnityEngine;

public class baseUPbutton : MonoBehaviour
{
    public baseUPmanager manager;
    public AudioClip upgradeSFX;
    public void baseUPclick()
    {
        int cost = manager.baseUPcost;
        if (data.money <= cost&&!manager.IsMaxLevel)
        {
            return;
        }
        audioManager.manager.playSFX(upgradeSFX, transform, data.sfx);
        clicker.clickStr++;
        data.baseUPlvl++;
        data.money -= cost;
    }
}