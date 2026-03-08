using System.Collections;
using UnityEngine;

public class critValue : MonoBehaviour
{
    public float duration = 30f;
    public bool isActive=false;
    IEnumerator critValuePerk()
    {
        isActive = true;
        data.critValue = 3;
        yield return new WaitForSeconds(duration);
        isActive = false;
        data.critValue = 2;
    }
    void onClick()
    {
        if (!isActive)
        {
            StartCoroutine(critValuePerk());
        }
    }
}
