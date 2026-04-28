using UnityEngine;

public class expUPButton : MonoBehaviour
{
    public expUPManager manager;

    public void expUPclick()
    {
        int cost = manager.expUPcost;
        if (data.money < cost)
        {
            return;
        }
        clicker.clickExp+=10;
        data.lvl++;
        data.money -= cost;
    }
}
