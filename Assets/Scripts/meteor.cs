using System.Buffers.Text;
using System.Collections;
using TMPro;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject met;
    public RectTransform metTrans;
    public TMP_Text metHp;
    public static int hpMeteor;
    public static int hpMaxMeteor;
    bool x = true;
    float dyingTime=0;
    float spawnDuration = 0.5f;
    float dyingDuration = 0.4f;
    float bounceDuration = 0.1f;
    private void meteorLvl()
    {
        data.meteorCrushed++;
        data.meteorlvl = (int)(15 * (1 + data.meteorCrushed/3 * 0.05f) * Mathf.Pow(1.05f, data.meteorCrushed/3));
    }
    IEnumerator Meteor()
    {
        data.money += hpMaxMeteor; //* petManager.globalMoneyMod;
        if (goldMeteorPerk.isActive)
        {
            data.money += hpMaxMeteor; //*petManager.globalMoneyMod * 4;
            goldMeteorPerk.isActive=false;
        }
        met.SetActive(false);
        meteorLvl();
        hpMaxMeteor = Random.Range(data.meteorlvl * 3, data.meteorlvl * 5);
        yield return new WaitForSeconds(1);
        met.SetActive(true);
        hpMeteor = hpMaxMeteor;
        yield return StartCoroutine(spawnAnimation()); 
        x = true;
    }

    private void Start()
    {
        hpMaxMeteor = Random.Range(data.meteorlvl * 3, data.meteorlvl * 5);
        hpMeteor = hpMaxMeteor;
    }
    public IEnumerator deathAnimation()
    {
        float pop = 0f;
        Vector3 startScale = Vector3.one;
        Vector3 popScale = new Vector3(1.1f, 1.1f, 1f);
        while (pop < 0.1f)
        {
            pop += Time.deltaTime;
            float t = pop / 0.1f;
            metTrans.localScale = Vector3.Lerp(startScale, popScale, t);
            yield return null;
        }
        dyingTime = 0f;
        while (dyingTime < dyingDuration)
        {
            dyingTime += Time.deltaTime;
            float t = dyingTime / dyingDuration;
            metTrans.localScale = Vector3.Lerp(popScale, Vector3.zero, t);
            yield return null;
        }
        metTrans.localScale = Vector3.zero;
        StartCoroutine(Meteor());
    }
    public IEnumerator spawnAnimation()
    {
        float time = 0f;
        Vector2 startPos = new Vector2(0, 800);
        Vector2 ground = Vector2.zero;
        Vector2 up = new Vector2(0, 60);
        metTrans.localScale = Vector3.one;
        while (time < spawnDuration)
        {
            time += Time.deltaTime;
            float t = time / spawnDuration;
            t = t * t;
            metTrans.anchoredPosition = Vector2.Lerp(startPos, ground, t);
            yield return null;
        }
        time = 0f;
        while (time < bounceDuration)
        {
            time += Time.deltaTime;
            float t = time / bounceDuration;

            metTrans.anchoredPosition = Vector2.Lerp(ground, up, t);
            yield return null;
        }
        time = 0f;
        while (time < bounceDuration)
        {
            time += Time.deltaTime;
            float t = time / bounceDuration;

            metTrans.anchoredPosition = Vector2.Lerp(up, ground, t);
            yield return null;
        }

        metTrans.anchoredPosition = ground;
    }
    public void Update()
    {
        metHp.text =hpMeteor +"/"+ hpMaxMeteor;
        if(x && hpMeteor <= 0)
        {
                StartCoroutine(deathAnimation());
                x = false;
        }
    }
}