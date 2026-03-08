using UnityEngine;

public class clicker : MonoBehaviour
{
    public static int clickStr = 1;

    public void click()
    {
        data.money += clickStr;
    }
    public void crit()
    {
        int r = UnityEngine.Random.Range(0, 100);
        if (r <= data.critUPlvl)
        {
            data.money += clickStr * 5;
        }
    }
}
