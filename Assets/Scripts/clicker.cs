using UnityEngine;
using TMPro;
using System.Collections;
public class clicker : MonoBehaviour
{
    public AudioClip clickSFX;
    public static int clickStr = 1;
    public static int clickExp = 10;
    public GameObject text;


    [Header ("autoClicker")]
    [SerializeField] autoClickerManager autoclick;
    public static bool autoClicker = false;
    public const float AutoClickerDuration = 30f;
    public bool isAutoClicking = false;
    public float autoClickerTimer;
    


    public void StartAutoClicker()
    {
        autoClickerTimer = AutoClickerDuration;
        autoClicker = true;
        Debug.Log("autocliker");
    }


    private void Update()
    {
        if (autoClicker)
        {
            if (autoClickerTimer <= 0f)
            {
                autoClicker = false;
                isAutoClicking = false;
            }

            if (!isAutoClicking)
            {
                StartCoroutine(autoclick.autoclick());
            }
        }
    }
    IEnumerator critText(GameObject text)
    {
        GameObject text1 = Instantiate(text, transform.position, Quaternion.identity);
        text1.SetActive(true);
        yield return null;
    }
    public void click()
    {
        //audioManager.manager.playSFX(clickSFX, transform, 1f);
        int critRate = (int)(data.critUPlvl + data.globalCritMod);
        meteor.hpMeteor -= clickStr;
        Debug.Log("click");
        if (!autoClicker)
        {
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
}
