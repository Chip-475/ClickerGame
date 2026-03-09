using UnityEngine;

public class baseUPbutton : MonoBehaviour
{
    public baseUPmanager manager;

    public void baseUPclick()
    {
        switch(data.baseUPlvl)
        {
            case 0:
                clicker.clickStr++;
                data.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 100;
                data.money -= 100;
                return;
            case 1:
                clicker.clickStr++;
                data.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 250;
                data.money -= 250;
                return;
            case 2:
                clicker.clickStr++;
                data.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 1000;
                data.money -= 1000;
                return;
            case 3:
                clicker.clickStr++;
                data.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 5000;
                data.money -= 5000;
                return;
            case 4:
                clicker.clickStr++;
                data.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 10000;
                data.money -= 10000;
                return;
        }
    }

}
