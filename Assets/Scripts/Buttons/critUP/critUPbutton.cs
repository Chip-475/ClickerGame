using UnityEngine;

public class critUPbutton : MonoBehaviour
{
    public critUPmanager manager;

    public void critUPclick()
    {
        int cost = manager.critUPcost;
        if (data.money < cost&&manager.IsMaxLevel)
        {
            return;
        }
        data.critUPlvl++;
        data.money -= cost;
    }
}
