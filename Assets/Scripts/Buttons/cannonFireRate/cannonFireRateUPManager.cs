using UnityEngine;
using TMPro;
public class cannonFireRateUPManager : MonoBehaviour
{
    [Header("oggetti")]
    public GameObject upgradeButton;
    public GameObject fakeButton;

    [Header("testo")]
    public TMP_Text header;
    public TMP_Text effect;
    public TMP_Text cost;

    [Header("fake testo")]
    public TMP_Text fakeHeader;
    public TMP_Text fakeEffect;
    public TMP_Text fakeCost;

    [Header("Upgrade Data")]
    public int[] levelCosts = { 150, 300, 600, 1200, 2500 };

    public int CurrentCost
    {
        get
        {
            if (data.cannonFireRatelvl >= levelCosts.Length)
            {
                return -1;
            }
            return levelCosts[data.cannonFireRatelvl];
        }
    }

    public bool IsMaxLevel => data.cannonFireRatelvl >= CurrentCost;

    void Update()
    {
        bool canBuy = !IsMaxLevel && data.money >= CurrentCost;

        if (upgradeButton != null)
        {
            upgradeButton.SetActive(canBuy);
        }
        if (fakeButton != null)
        {
            fakeButton.SetActive(!canBuy);
        }

        float reduction = data.fireRateReductionPerLevel;
        string headerText = "Cannon Fire Rate UP<br>Lv. " + data.cannonFireRatelvl;
        string costText = IsMaxLevel ? "MAX" : "Cost: " + CurrentCost;
        string effectText = "-" + reduction.ToString("0.00") + "s";

        if (header != null) header.text = headerText;
        if (cost != null) cost.text = costText;
        if (effect != null) effect.text = effectText;

        if (fakeHeader != null) fakeHeader.text = headerText;
        if (fakeCost != null) fakeCost.text = costText;
        if (fakeEffect != null) fakeEffect.text = effectText;
    }
}