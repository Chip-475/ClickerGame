using UnityEngine;

public class clicker : MonoBehaviour
{

    public static int clickStr = 1;

    public void click()
    {
        data.money += clickStr;
    }

}
