using UnityEngine;
using TMPro;
public class cannonFireRateUPManager : MonoBehaviour
{
    private const int CostStep = 50;
    [Header("oggetti")]
    public GameObject upgradeButton;
    public GameObject fakeButton;

    [Header("testo")]
    public TMP_Text header;
    public TMP_Text cost;

    [Header("fake testo")]
    public TMP_Text fakeHeader;
    public TMP_Text fakeCost;

    [Header("Stats")]
    public int fireRateUPCost;
    public int maxLevel = 50;
    public int startingCost = 300;

    public bool IsMaxLevel = false;

    void Update()
    {
        if (data.lvl >= maxLevel && !IsMaxLevel)
        {
            IsMaxLevel = true;
        }

        fireRateUPCost = GetCostForLevel();

        if (data.money >= fireRateUPCost && !IsMaxLevel && data.cannon1) { fakeButton.SetActive(false); upgradeButton.SetActive(true); }
        else { upgradeButton.SetActive(false); fakeButton.SetActive(true); }

        string headerText = "Cannon Fire Rate UP<br>Lv. " + data.cannonFireRatelvl;
        string costText ="Cost: " + fireRateUPCost;

        header.text = headerText;
        cost.text = costText;
        fakeHeader.text = headerText;
        fakeCost.text = costText;
        if (IsMaxLevel)
        {
            fakeCost.text = "MAX LVL";
        }
    }
    public int GetCostForLevel()
    {
        float rawCost = startingCost * Mathf.Pow(1.30f, data.lvl);
        return Mathf.RoundToInt(rawCost / CostStep) * CostStep;
    }
}