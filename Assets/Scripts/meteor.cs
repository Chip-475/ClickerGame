using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class meteor : MonoBehaviour
{
    public GameObject met;
    public AudioClip explodeSFX;
    public TMP_Text metHp;
    public static int hpMeteor;
    public static int hpMaxMeteor;
    bool isAlive = true;
    public RectTransform rect;
    public Sprite defaultMeteor;
    public Sprite goldMeteor;
    Vector2 targetPos = Vector2.zero;
    //for hackclub reviewer:fuck this shit don't even try to understand why this work
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
        hpMaxMeteor = Random.Range(data.meteorlvl * 2, data.meteorlvl * 4);
        hpMeteor = hpMaxMeteor;
        rect.localScale = Vector3.one;
        rect.anchoredPosition = new Vector2(Random.Range(-300f, 300f), 1000f);

        isAlive = true;
        Image meteorImage = met.GetComponent<Image>();
        if (goldMeteorPerk.isActive)
        {
            meteorImage.sprite = goldMeteor;
        }
        else
        {
            meteorImage.sprite = defaultMeteor;
        }
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
        audioManager.manager.playSFX(explodeSFX, transform, data.sfx);
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
        data.totalMoney += reward;
        if (goldMeteorPerk.isActive)
        {
            data.money += reward;
            data.totalMoney += reward;
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
        data.meteorlvl = Mathf.RoundToInt(3f+Mathf.Pow(data.meteorCrushed,1.18f));
    }
}
