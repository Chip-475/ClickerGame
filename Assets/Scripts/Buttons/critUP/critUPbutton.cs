using UnityEngine;

public class critUPbutton : MonoBehaviour
{

    public critUPmanager manager;

    public void critUPclick()
    {
        switch (data.critUPlvl)
        {
            case 0:
                data.critUPlvl++;
                manager.critUPcost = 100;
                return;
            case 1:
                data.critUPlvl++;
                manager.critUPcost = 250;
                return;
            case 2:
                data.critUPlvl++;
                manager.critUPcost = 1000;
                return;
            case 3:
                data.critUPlvl++;
                manager.critUPcost = 5000;
                return;
            case 4:
                data.critUPlvl++;
                manager.critUPcost = 10000;
                return;
        }
    }
}

