using UnityEngine;
using TMPro;
using System.Collections;
public class clicker : MonoBehaviour
{
    public AudioClip clickSFX;
    public static int clickStr = 1;
    public static int clickExp = 10;
    public GameObject text;


    [Header("autoClicker")]
    [SerializeField] autoClickerManager autoclick;
    public static bool autoClicker = false;
    public static float AutoClickerDuration = 30f;

    public void startAutoclicker()
    {
        autoClickerManager.Instance.stavoltastartadavverolautoclicker();
    }
    private void Update()
    {

    }
    IEnumerator critText(GameObject text)
    {
        GameObject text1 = Instantiate(text, transform.position, Quaternion.identity);
        text1.SetActive(true);
        yield return null;
    }
    public void click()
    {
        audioManager.manager.playSFX(clickSFX, transform, data.sfx);
        data.totalClicks++;
        int critRate = (int)(data.critUPlvl + data.globalCritMod);
        meteor.hpMeteor -= clickStr;
        Debug.Log("click");
        data.xp += clickExp;
        int r = UnityEngine.Random.Range(0, critRate);
        if (r < critRate)
        {
            data.xp += clickExp * data.critDmg;
            meteor.hpMeteor -= clickStr * data.critDmg;
            StartCoroutine(critText(text));
            Debug.Log(meteor.hpMeteor);
        }
    }
}
