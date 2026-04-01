using UnityEngine;
using System.Collections;
public class baseClickPerk : MonoBehaviour
{
    public float duration = 30f;
    public bool isActive = false;
    public IEnumerator ClickPerk()
    {
        isActive = true;
        clicker.clickStr *= 2;
        yield return new WaitForSeconds(duration);
        isActive = false;
        clicker.clickStr /= 2;
    }
    public void onClick()
    {
        if (!isActive)
        {
            StartCoroutine(ClickPerk());
            data.clickPerk--;
        }
    }
}
