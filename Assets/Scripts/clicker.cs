using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor;
public class clicker : MonoBehaviour
{
    public static int clickStr = 1;
    public static int clickExp = 10;
    public static bool autoClicker = false;
    private float autoClickerTimer = 30f;
    public GameObject text;

  /*  IEnumerator autoclick()
    {
        click();
        yield return new WaitForSeconds(0.2f);
        autoClickerTimer -= 0.2f;
    }
    private void Update()
    {
        if (autoClicker)
        {
            StartCoroutine(autoclick());
            autoClicker = false;
        }
    }*/
    IEnumerator critText(GameObject text)
    {
        GameObject text1 = GameObjectUtility.DuplicateGameObject(text);
        text1.SetActive(true);
        Instantiate(text1, transform.position, Quaternion.identity);
        yield return null;
    }
    public void click()
    {
        meteor.hpMeteor -= clickStr;
        if (!autoClicker)
        {
            data.exp += clickExp;
            int r = UnityEngine.Random.Range(0, 9);
            if (r < data.critUPlvl)
            {
                data.critMoney++;
                data.exp += clickExp * data.critDmg;
                meteor.hpMeteor -= clickStr * data.critDmg;
                StartCoroutine(critText(text));
                Debug.Log(meteor.hpMeteor);
            }
        }
    }
}
