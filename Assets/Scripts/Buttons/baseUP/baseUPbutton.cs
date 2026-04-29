using UnityEngine;

public class baseUPbutton : MonoBehaviour
{
    public baseUPmanager manager;

    public void baseUPclick()
    {
        int cost = manager.baseUPcost;
        if (data.money <= cost&&!manager.IsMaxLevel)
        {
            return;
        }
        clicker.clickStr++;
        data.baseUPlvl++;
        data.money -= cost;
    }
}