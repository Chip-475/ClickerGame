using UnityEngine;
using System.Collections;
public class baseClickPerk : MonoBehaviour
{
    public float duration = 30f;
    static public bool isActive = false;
    public IEnumerator ClickPerk()
    {
        data.clickPerk--;
        isActive = true;
        clicker.clickStr *= 2;
        yield return new WaitForSeconds(duration);
        clicker.clickStr /= 2;
        isActive = false;
    }
    public void onClick()
    {
        StartCoroutine(ClickPerk());
    }
}
