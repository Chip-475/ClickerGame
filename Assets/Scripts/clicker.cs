using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor;
public class clicker : MonoBehaviour
{
    public static int clickStr = 1;
    public static int clickExp = 10;
    public GameObject text;
    IEnumerator critText(GameObject text)
    {
        GameObject text1 = GameObjectUtility.DuplicateGameObject(text);
        text1.SetActive(true);
        Instantiate(text1, transform.position, Quaternion.identity);
        yield return null;
    }
    public void click()
    {
        data.money += clickStr;
        data.exp += clickExp;
        int r = UnityEngine.Random.Range(0, 9);
        if (r < data.critUPlvl)
        {
            data.critMoney++;
            data.exp += clickExp*data.critDmg;
            data.money += clickStr * data.critDmg;
            StartCoroutine(critText(text));
        }
    }
}
