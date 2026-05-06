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
        data.fuel1=Mathf.Clamp(data.money, 0, cannon_1.totalDepot);
        data.money -= 100;
    }
}
