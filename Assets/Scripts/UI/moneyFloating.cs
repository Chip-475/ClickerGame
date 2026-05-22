using UnityEngine;
using TMPro;
using System.Collections;


public class moneyFloating : MonoBehaviour
{
    public static int reward;
    public RectTransform rect;
    public TMP_Text text;
    void Start()
    {
        Destroy(gameObject,1.5f);
        text = GetComponent<TMP_Text>();
        text.text="+"+reward.ToString();
        rect= GetComponent<RectTransform>();
        StartCoroutine(floating());
    }
    IEnumerator floating()
    {
        float bounceHeight = 100f;
        Vector2 target = this.rect.anchoredPosition + Vector2.up * bounceHeight;
        while (rect.anchoredPosition.y < target.y)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, target, 66f * Time.deltaTime);
            text.color= new Color(255f, 255f, 255f,Mathf.MoveTowards(text.color.a,0,0.66f*Time.deltaTime));
            yield return null;
        }
    }
}
