using UnityEngine;

public class baseUPbutton : MonoBehaviour
{
    
    public baseUPmanager manager;

    public void baseUPclick()
    {
        switch(manager.baseUPlvl)
        {
            case 0:
                clicker.clickStr++;
                manager.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 100;
                return;
            case 1:
                clicker.clickStr++;
                manager.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 250;
                return;
            case 2:
                clicker.clickStr++;
                manager.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 1000;
                return;
            case 3:
                clicker.clickStr++;
                manager.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 5000;
                return;
            case 4:
                clicker.clickStr++;
                manager.baseUPlvl++;
                manager.baseUPeffect++;
                manager.baseUPcost = 10000;
                return;
        }
    }
}
