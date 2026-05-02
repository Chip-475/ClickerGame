using System.Collections;
using UnityEngine;

public class critPerk : MonoBehaviour
{
    public float duration = 30f;
    static public bool isActive=false;
    public  IEnumerator critValuePerk()
    {
        data.critPerkAmount--;
        data.perkUsed++;
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