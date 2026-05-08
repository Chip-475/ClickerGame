using UnityEngine;

public class Fuel : MonoBehaviour
{
    public void OnClick()
    {
        if(data.fuel1>=cannon_1.totalDepot)
        {
            return;
        }
        if (data.money < 500)
        {
            return;
        }
        data.fuel1=Mathf.Clamp(data.fuel1+20, 0, cannon_1.totalDepot);
        data.money -= 500;
    }
}
