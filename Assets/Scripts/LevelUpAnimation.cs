using UnityEngine;
using TMPro;
using Unity.Android.Gradle.Manifest;
using System.Collections;
public class LevelUpAnimation : MonoBehaviour
{
    TMP_Text lvlUPtxt;
    GameObject imgLvl;
    GameObject safeArea;
    RectTransform imgTrans;
    float AnimTime = 0f;
    float AnimDuration=2f;
    //gran dio cane
    void Start()
    {
        imgTrans = GetComponent<RectTransform>();
        safeArea = GameObject.FindGameObjectWithTag("SafeArea");
        imgLvl = gameObject;
        imgLvl.transform.SetParent(safeArea.transform);
        imgTrans.anchoredPosition=xpManager.Image_Pos;
        lvlUPtxt =GetComponentInChildren<TMP_Text>();
        lvlUPtxt.text = "New Level:" + data.lvl + "\n Obtained:" + data.lvl * 50;
        StartCoroutine(playAnim());
    }
    public  IEnumerator playAnim()
    {
        while(AnimTime <= AnimDuration/2f)
        {
            AnimTime += Time.deltaTime;
            float t = AnimTime / (AnimDuration/2f);
            imgTrans.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
        AnimTime = 0f;
        yield return new WaitForSeconds(2f);
        while (AnimTime <= AnimDuration / 2f)
        {
            AnimTime += Time.deltaTime;
            float t = AnimTime / (AnimDuration/2f);
            imgTrans.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }
            Destroy(gameObject);
    }
}
