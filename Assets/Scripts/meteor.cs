using System.Collections;
using TMPro;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject met;
    public TMP_Text metHp;
    public static int hpMeteor;
    public static int hpMaxMeteor;
    bool isAlive = true;
    public RectTransform rect;
    Vector2 targetPos = Vector2.zero;
    void Start()
    {
        ResetMeteor();
        StartCoroutine(FallAndBounce());
    }

    void Update()
    {
        metHp.text = hpMeteor + "/" + hpMaxMeteor;

        if (isAlive && hpMeteor <= 0)
        {
            isAlive = false;
            StartCoroutine(DeathAnimation());
        }
    }

    void ResetMeteor()
    {
        hpMaxMeteor = Random.Range(data.meteorlvl * 3, data.meteorlvl * 5);
        hpMeteor = hpMaxMeteor;
        rect.localScale = Vector3.one;
        rect.anchoredPosition = new Vector2(Random.Range(-300f, 300f), 1000f);

        isAlive = true;
    }

    IEnumerator FallAndBounce()
    {
        float speed = 2000f;
        float bounceHeight = 150f;
        while (rect.anchoredPosition.y > targetPos.y)
        {
            rect.anchoredPosition = Vector2.MoveTowards(
                rect.anchoredPosition,
                targetPos,
                speed * Time.deltaTime
            );
            yield return null;
        }
        Vector2 bounceTarget = targetPos + Vector2.up * bounceHeight;
        while (rect.anchoredPosition.y < bounceTarget.y)
        {
            rect.anchoredPosition = Vector2.MoveTowards(
                rect.anchoredPosition,
                bounceTarget,
                speed * Time.deltaTime
            );
            yield return null;
        }
        while (rect.anchoredPosition.y > targetPos.y)
        {
            rect.anchoredPosition = Vector2.MoveTowards(
                rect.anchoredPosition,
                targetPos,
                speed * Time.deltaTime
            );
            yield return null;
        }

        rect.anchoredPosition = targetPos;
    }

    IEnumerator DeathAnimation()
    {
        float popTime = 0.1f;
        float t = 0;

        Vector3 start = Vector3.one;
        Vector3 pop = Vector3.one * 1.4f;

        while (t < popTime)
        {
            t += Time.deltaTime;
            rect.localScale = Vector3.Lerp(start, pop, t / popTime);
            yield return null;
        }
        float shrinkTime = 0.25f;
        t = 0;

        while (t < shrinkTime)
        {
            t += Time.deltaTime;
            rect.localScale = Vector3.Lerp(pop, Vector3.zero, t / shrinkTime);
            yield return null;
        }

        yield return StartCoroutine(MeteorRespawn());
    }

    IEnumerator MeteorRespawn()
    {
        int reward = Mathf.RoundToInt(hpMaxMeteor * data.globalMoneyMod);
        data.money += reward;

        if (goldMeteorPerk.isActive)
        {
            data.money += reward;
            goldMeteorPerk.isActive = false;
        }

        met.SetActive(false);

        meteorLvl();

        yield return new WaitForSeconds(1.5f);

        ResetMeteor();
        met.SetActive(true);

        StartCoroutine(FallAndBounce());
    }

    void meteorLvl()
    {
        data.meteorCrushed++;

        data.meteorlvl = (int)(
            15 *
            (1 + data.meteorCrushed / 3f * 0.05f) *
            Mathf.Pow(1.05f, data.meteorCrushed / 3f)
        );
    }
}
