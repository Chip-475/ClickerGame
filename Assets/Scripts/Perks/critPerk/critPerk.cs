using System.Collections;
using UnityEngine;

public class critPerk : MonoBehaviour
{
    public float duration = 30f;
<<<<<<< Updated upstream:Assets/Scripts/Perks/critPerk/critPerk.cs
    static public bool isActive=false;
=======
    public static bool isActive=false;
>>>>>>> Stashed changes:Assets/Scripts/Perks/critPerk.cs
    public  IEnumerator critValuePerk()
    {
        data.critPerkAmount--;
        isActive = true;
        data.critDmg *= 2;
        yield return new WaitForSeconds(duration);
        data.critDmg /= 2;
        isActive = false;
    }
    public  void onClick()
    {
        if (!isActive)
        {
            StartCoroutine(critValuePerk());
        }
    }
}