using System.Collections;
using UnityEngine;

public class critPerk : MonoBehaviour
{
    public float duration = 30f;
    public bool isActive=false;
    IEnumerator critValuePerk()
    {
        isActive = true;
        data.critDmg *= 2;
        yield return new WaitForSeconds(duration);
        isActive = false;
        data.critDmg /= 2;
    }
    void onClick()
    {
        if (!isActive)
        {
            StartCoroutine(critValuePerk());
        }
    }
}
