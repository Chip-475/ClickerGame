using UnityEngine;
using TMPro;
using System.Collections;
public class clicker : MonoBehaviour
{
    public AudioClip clickSFX;
    public AudioClip critSFX;
    public static int clickStr = 1;
    public static int clickExp = 10;
    public GameObject text;
    public static int critRate;

    [Header("autoClicker")]
    [SerializeField] autoClickerManager autoclick;
    public static bool autoClicker = false;
    public static float AutoClickerDuration = 30f;

    public void startAutoclicker()
    {
        autoClickerManager.Instance.stavoltastartadavverolautoclicker();
    }
    IEnumerator critText(GameObject text)
    {
        GameObject text1 = Instantiate(text, transform.position, Quaternion.identity,transform);
        text1.SetActive(true);
        yield return null;
    }
    public void click()
    {
        audioManager.manager.playSFX(clickSFX, transform, data.sfx);
        data.totalClicks++;
        critRate = Mathf.Clamp((int)(data.critUPlvl + data.globalCritMod),0,75);
        if (baseClickPerk.isActive)
        {
            meteor.hpMeteor = Mathf.Clamp(meteor.hpMeteor - (clickStr * 2), 0, meteor.hpMeteor);
        }
        else
        {
            meteor.hpMeteor = Mathf.Clamp(meteor.hpMeteor - clickStr, 0, meteor.hpMeteor);
        }
        Debug.Log("click");
        data.xp += clickExp;
        int r = UnityEngine.Random.Range(0, 100);
        if (r < critRate)
        {
            audioManager.manager.playSFX(critSFX, transform, data.sfx);
            data.xp += clickExp * data.critDmg;
            if(baseClickPerk.isActive^critPerk.isActive)
            {
                meteor.hpMeteor = Mathf.Clamp(meteor.hpMeteor - (clickStr * 2*data.critDmg), 0, meteor.hpMeteor);
            }
            if(critPerk.isActive&&baseClickPerk.isActive)
            {
                meteor.hpMeteor = Mathf.Clamp(meteor.hpMeteor - (clickStr * 4 * data.critDmg), 0, meteor.hpMeteor);
            }
            if (!baseClickPerk.isActive && !critPerk.isActive)
            {
                meteor.hpMeteor = Mathf.Clamp(meteor.hpMeteor - (clickStr * 2 * data.critDmg), 0, meteor.hpMeteor);
            }
            StartCoroutine(critText(text));
            Debug.Log("crit");
        }
    }
}
