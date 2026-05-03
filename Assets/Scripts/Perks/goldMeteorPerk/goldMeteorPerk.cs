using UnityEngine;
using System.Collections;
public class goldMeteorPerk : MonoBehaviour
{
    public static bool isActive = false;

    public void onClick()
    {
        if (!isActive && data.goldMeteorAmount > 0)
        {
            isActive = true;
            data.goldMeteorAmount--;
            data.perkUsed++;
        }
    }
}
