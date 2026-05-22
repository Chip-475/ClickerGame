using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class offlineReward : MonoBehaviour
{
    private const int UnlockLevel = 10;
    private const double MinOfflineSeconds = 60;
    private const double MaxOfflineSeconds = 4d * 60d * 60d;
    private const float OfflineEfficiency = 0.25f;
    private const float PopupDuration = 4f;
    private const float FadeDuration = 1f;

    private static offlineReward instance;
    private static GameObject popupObject;
    private Coroutine popupCoroutine;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        if (instance != null)
        {
            return;
        }
        GameObject rewardObject = new GameObject("offlineReward");
        instance = rewardObject.AddComponent<offlineReward>();
        DontDestroyOnLoad(rewardObject);
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(SaveAndLoad.HasLoaded);
        Apply(SaveAndLoad.LastLoadedUtcTicks);
        if (data.offlineBonusReward > 0)
        {
            ShowOfflineRewardPopup();
            SaveAndLoad.SaveNow();
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus || !SaveAndLoad.HasLoaded())
        {
            return;
        }

        Apply(SaveAndLoad.LastSavedUtcTicks);
        if (data.offlineBonusReward > 0)
        {
            ShowOfflineRewardPopup();
            SaveAndLoad.SaveNow();
        }
    }

    public static void Apply(long savedUtcTicks)
    {
        ResetState();

        if (data.lvl < UnlockLevel)
        {
            return;
        }

        if (savedUtcTicks <= 0)
        {
            return;
        }

        double offlineSeconds = (DateTime.UtcNow - new DateTime(savedUtcTicks, DateTimeKind.Utc)).TotalSeconds;
        if (offlineSeconds < MinOfflineSeconds)
        {
            return;
        }

        offlineSeconds = Math.Min(offlineSeconds, MaxOfflineSeconds);

        int clickPower = Mathf.Max(1, clicker.clickStr);
        float moneyModifier = Mathf.Max(1f, data.globalMoneyMod);
        int moneyRoom = Mathf.Max(0, int.MaxValue - data.money);
        double rawReward = offlineSeconds * clickPower * moneyModifier * OfflineEfficiency;
        int reward = Mathf.RoundToInt((float)Math.Min(rawReward, moneyRoom));

        if (reward <= 0)
        {
            return;
        }

        data.money += reward;
        data.totalMoney += reward;
        data.offlineBonusReward = reward;
        data.offlineBonusSeconds = offlineSeconds;
    }

    public static void ResetState()
    {
        data.offlineBonusReward = 0;
        data.offlineBonusSeconds = 0;
    }

    private void ShowOfflineRewardPopup()
    {
        if (data.offlineBonusReward <= 0)
        {
            return;
        }

        Canvas canvas = FindAnyObjectByType<Canvas>();

        Transform parent = canvas.transform.Find("safeArea") ?? canvas.transform;
        popupObject = BuildPopup(parent);
        popupObject.transform.SetAsLastSibling();

        TMP_Text rewardText = popupObject.GetComponentInChildren<TMP_Text>();
        rewardText.text = $"Offline earnings:\n+{data.offlineBonusReward} Money\n{FormatOfflineTime(data.offlineBonusSeconds)}";

        if (popupCoroutine != null)
        {
            StopCoroutine(popupCoroutine);
        }

        popupCoroutine = StartCoroutine(HidePopupAfterDelay(popupObject));
    }

    private static GameObject BuildPopup(Transform parent)
    {
        if (popupObject != null)
        {
            Destroy(popupObject);
        }

        GameObject container = new GameObject("OfflineRewardPopup", typeof(RectTransform), typeof(CanvasGroup), typeof(Image));
        container.transform.SetParent(parent, false);

        RectTransform rect = container.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 1f);
        rect.anchorMax = new Vector2(0.5f, 1f);
        rect.pivot = new Vector2(0.5f, 1f);
        rect.anchoredPosition = new Vector2(0f, -140f);
        rect.sizeDelta = new Vector2(520f, 180f);

        Image background = container.GetComponent<Image>();
        background.color = new Color(0f, 0f, 0f, 0.72f);

        GameObject textObject = new GameObject("OfflineRewardText", typeof(RectTransform), typeof(TextMeshProUGUI));
        textObject.transform.SetParent(container.transform, false);

        RectTransform textRect = textObject.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = new Vector2(24f, 16f);
        textRect.offsetMax = new Vector2(-24f, -16f);

        TextMeshProUGUI text = textObject.GetComponent<TextMeshProUGUI>();
        text.alignment = TextAlignmentOptions.Center;
        text.enableAutoSizing = true;
        text.fontSizeMin = 24f;
        text.fontSizeMax = 42f;
        text.color = Color.white;

        return container;
    }

    private IEnumerator HidePopupAfterDelay(GameObject popup)
    {
        yield return new WaitForSeconds(Mathf.Max(0f, PopupDuration - FadeDuration));

        CanvasGroup canvasGroup = popup != null ? popup.GetComponent<CanvasGroup>() : null;
        if (canvasGroup != null)
        {
            float elapsed = 0f;
            while (elapsed < FadeDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / FadeDuration);
                yield return null;
            }
        }

        if (popup != null)
        {
            Destroy(popup);
        }

        popupCoroutine = null;
    }

    private static string FormatOfflineTime(double seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);

        if (time.TotalHours >= 1)
        {
            return $"{(int)time.TotalHours}h {time.Minutes}m offline";
        }

        return $"{Mathf.Max(1, time.Minutes)}m offline";
    }
}
