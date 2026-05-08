using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Egganimation : MonoBehaviour
{
    public GameObject egg1;
    public GameObject egg2;
    public GameObject egg3;
    public GameObject egg4;
    public GameObject egg5;
    public float width;
    public float height;
    public static bool isPulling;
    public Transform shop;
    public GameObject exit;
    public Button exitButton;
    public Image exitImage;
    public Color gray;

    float[] values = { -10f, 10f, -20f, 20f, -30f, 30f,0f,0f };
    public GameObject animationEgg;
    public RectTransform animRect;
    public petStats stats;
    public AudioClip pullSFX;
    private void Start()
    {
        height = egg1.GetComponent<RectTransform>().rect.height;
        width = egg1.GetComponent<RectTransform>().rect.width;
        stats=GetComponent<petStats>();
        exitButton = exit.GetComponent<Button>();
        exitImage = exit.GetComponent<Image>();
        UnityEngine.ColorUtility.TryParseHtmlString("#5A5A5A", out gray);
    }
    public IEnumerator pullAnim(int openedEgg)
    {
        exitButton.interactable = false;
        exitImage.color=gray;
        audioManager.manager.playSFX(pullSFX, transform, data.sfx);
        isPulling = true;
        animationEgg = Instantiate(new GameObject());
        Debug.Log("instaziato");
        yield return new WaitForSeconds(1f);
        animationEgg.AddComponent<Image>();
        animationEgg.AddComponent<RectTransform>();
        animRect = animationEgg.GetComponent<RectTransform>();
        animRect.SetParent(shop);
        Debug.Log(openedEgg);
        if (openedEgg == 1)
        {
            animRect.anchoredPosition=egg1.GetComponent<RectTransform>().anchoredPosition;
            animRect.sizeDelta=new Vector2(width, height);
            animationEgg.GetComponent<Image>().sprite = egg1.GetComponent<Image>().sprite;
            Debug.Log(egg1.GetComponent<Image>().sprite);
        }
        if (openedEgg == 2)
        {
            animRect.anchoredPosition = egg2.GetComponent<RectTransform>().anchoredPosition;
            animRect.sizeDelta = new Vector2(width, height);
            animationEgg.GetComponent<Image>().sprite = egg2.GetComponent<Image>().sprite;
        }
        if (openedEgg == 3)
        {
            animRect.anchoredPosition = egg3.GetComponent<RectTransform>().anchoredPosition;
            animRect.sizeDelta = new Vector2(width, height);
            animationEgg.GetComponent<Image>().sprite = egg3.GetComponent<Image>().sprite;
        }
        if (openedEgg == 4)
        {
            animRect.anchoredPosition = egg4.GetComponent<RectTransform>().anchoredPosition;
            animRect.sizeDelta = new Vector2(width, height);
            animationEgg.GetComponent<Image>().sprite = egg4.GetComponent<Image>().sprite;
        }
        if (openedEgg == 5)
        {
            animRect.anchoredPosition = egg5.GetComponent<RectTransform>().anchoredPosition;
            animRect.sizeDelta = new Vector2(width, height);
            animationEgg.GetComponent<Image>().sprite = egg5.GetComponent<Image>().sprite;
        }
        Vector2 startPosition = animRect.anchoredPosition;
        Vector2 centerPosition = Vector2.zero;
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            animRect.anchoredPosition = Vector2.Lerp(startPosition, centerPosition, t);
            yield return null;
        }//centering
        animRect.anchoredPosition = centerPosition;
        duration = 1f/7f;
        for (int i = 0;i<8;i++)
        {
            elapsed = 0f;
            while(elapsed <= duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                animRect.rotation=Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, values[i]), t);
                yield return null;
            }
        }//shaking
        duration = 0.5f;
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            animRect.localScale=Vector3.Lerp(Vector3.one,Vector3.zero, t);
            yield return null;
        }//despawn
        animationEgg.GetComponent<Image>().sprite = stats.GetPetData(gachaSystem.lastPulled).sprite;
        Debug.Log(stats.GetPetData(gachaSystem.lastPulled).sprite);
        duration = 0.7f;
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            animRect.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t );
            yield return null;
        }//petSpawning
        yield return new WaitForSeconds(1.5f);
        duration = 0.3f;
        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            animRect.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, t);
            yield return null;
        }//petDespawn
        Destroy(animationEgg);
        yield return null;
        isPulling = false;
        exitButton.interactable = true;
        exitImage.color = Color.white;
    }
}
