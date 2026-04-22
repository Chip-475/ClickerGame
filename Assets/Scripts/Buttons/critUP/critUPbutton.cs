using UnityEngine;

public class critUPbutton : MonoBehaviour
{
    public critUPmanager manager;
    public float baseCost = 100;
    public float rawCost = 100;
    public void critUPclick()
    {
        if (data.critUPlvl < 51)
        {
            data.critUPlvl++;
            rawCost = baseCost * Mathf.Pow(1.13f, data.critUPlvl) * Mathf.Pow(data.critUPlvl + 1, 1.4f);
            manager.critUPcost = Mathf.RoundToInt(rawCost / 50f) * 50;
        }
    }
}

