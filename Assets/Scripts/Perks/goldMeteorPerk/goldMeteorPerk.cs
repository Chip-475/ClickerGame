using UnityEngine;
using System.Collections;
public class goldMeteorPerk : MonoBehaviour
{
    public static bool isActive=false;
    public void onClick()
    {
        if (!isActive)
        {
            isActive = true;
            data.critPerkAmount--;
            data.perkUsed++;
        }
    }
}
