using System.Collections;
using UnityEngine;

public class critPerk : MonoBehaviour
{
    public float duration = 30f;
    static public bool isActive=false;
    public GameObject timer;
    public GameObject point;
    public  IEnumerator critValuePerk()
    {
        data.critPerkAmount--;
        data.perkUsed++;
        isActive = true;
        Instantiate(timer, point.transform);
        yield return new WaitForSeconds(duration);
        isActive = false;
    }
    public  void onClick()
    {
        if (!isActive)
        {
            if (isActive || data.critPerkAmount <= 0) return;
            StartCoroutine(critValuePerk());
        }
    }
}