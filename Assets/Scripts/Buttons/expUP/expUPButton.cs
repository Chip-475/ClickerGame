using UnityEngine;

public class expUPButton : MonoBehaviour
{
    public expUPManager manager;

    public void baseUPclick()
    {
        switch(data.explvl)
        {
            case 0:
                clicker.clickExp++;
                data.explvl++;
                manager.expUPeffect++;
                manager.expUPcost = 100;
                data.money -= 100;
                return;
            case 1:
                clicker.clickExp++;
                data.explvl++;
                manager.expUPeffect++;
                manager.expUPcost = 250;
                data.money -= 250;
                return;
            case 2:
                clicker.clickExp++;
                data.explvl++;
                manager.expUPeffect++;
                manager.expUPcost = 1000;
                data.money -= 1000;
                return;
            case 3:
                clicker.clickExp++;
                data.explvl++;
                manager.expUPeffect++;
                manager.expUPcost = 5000;
                data.money -= 5000;
                return;
            case 4:
                clicker.clickExp++;
                data.explvl++;
                manager.expUPeffect++;
                manager.expUPcost = 10000;
                data.money -= 10000;
                return;
        }
    }

}
