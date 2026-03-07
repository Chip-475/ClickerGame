using UnityEngine;

public class button : MonoBehaviour
{

    public buttonManager manager;

    public void baseUPclick() // ogni stats in base al livello corrente
    {
        switch (data.baseUPlvl)
        {
            case 0:
                clicker.clickStr++;
                manager.baseUPeffect++;
                manager.baseUPcost = 100;
                return;
            case 1:
                clicker.clickStr++;
                manager.baseUPeffect++;
                manager.baseUPcost = 250;
                return;
            case 2:
                clicker.clickStr++;
                manager.baseUPeffect++;
                manager.baseUPcost = 1000;
                return;
            case 3:
                clicker.clickStr++;
                manager.baseUPeffect++;
                manager.baseUPcost = 5000;
                return;
            case 4:
                clicker.clickStr++;
                manager.baseUPeffect++;
                manager.baseUPcost = 10000;
                return;
        }
    }
}
