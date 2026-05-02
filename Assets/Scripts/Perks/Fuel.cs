using UnityEngine;

public class Fuel : MonoBehaviour
{
    public void OnClick()
    {
        if(data.fuel1>=cannon_1.totalDepot)
        {
            return;
        }
        if (data.money <= 100)
        {
            return;
        }
        data.fuel1 += 100;
    }
}
