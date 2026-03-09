using UnityEngine;
using TMPro;
using System.Collections;
using UnityEditor;
public class clicker : MonoBehaviour
{
    public static int clickStr = 1;
    public GameObject text;

    public void click()
    {
        data.money += clickStr;
    }

    IEnumerator critText(GameObject text)
    {
        GameObject text1 = GameObjectUtility.DuplicateGameObject(text);
        text1.SetActive(true);
        Instantiate(text1, transform.position, Quaternion.identity);
        yield return null;
    }
    public void crit()
    {
        int r = UnityEngine.Random.Range(0, 9);
        if (r < data.critUPlvl)
        {
            data.money += clickStr * data.critDmg;
            StartCoroutine(critText(text));
        }
    }
}
