using UnityEngine;
using System.Collections;
public class baseClickPerk : MonoBehaviour
{
    public float duration = 30f;
<<<<<<< Updated upstream:Assets/Scripts/Perks/basePerk/baseClickPerk.cs
    static public bool isActive = false;
=======
    public static bool isActive = false;
>>>>>>> Stashed changes:Assets/Scripts/Perks/baseClickPerk.cs
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
