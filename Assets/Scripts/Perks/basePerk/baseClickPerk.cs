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
        clicker.clickStr *= 2;
        Instantiate(timer, point.transform);
        yield return new WaitForSeconds(duration);
        clicker.clickStr /= 2;
        isActive = false;
    }
    public void onClick()
    {
        StartCoroutine(ClickPerk());
    }
}
