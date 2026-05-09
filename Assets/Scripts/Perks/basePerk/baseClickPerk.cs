using UnityEngine;
using System.Collections;
using System.Drawing;

public class baseClickPerk : MonoBehaviour
{
    public float duration = 30f;
    static public bool isActive = false;
    public GameObject timer;
    public GameObject point;
    public IEnumerator ClickPerk()
    {
        data.clickPerkAmount--;
        data.perkUsed++;
        isActive = true;
        Instantiate(timer, point.transform);
        yield return new WaitForSeconds(duration);
        isActive = false;
    }
    public void onClick()
    {
        if (isActive || data.clickPerkAmount <= 0) return;
        StartCoroutine(ClickPerk());
    }
}
