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
    public int maxLevel = 25;
    public int startingCost = 300;

    public bool IsMaxLevel = false;

    void Update()
    {
        if (data.cannonFireRatelvl >= maxLevel && !IsMaxLevel)
        {
            IsMaxLevel = true;
        }

        fireRateUPCost = GetCostForLevel();

        if (data.money >= fireRateUPCost && !IsMaxLevel && data.cannon1) { fakeButton.SetActive(false); upgradeButton.SetActive(true); }
        else { upgradeButton.SetActive(false); fakeButton.SetActive(true); }

        header.text = "Upgrade Fire Rate<br>" + "Lv. " + data.cannonFireRatelvl;
        cost.text = "Cost: " + fireRateUPCost;
        fakeHeader.text = "Upgrade Fire Rate<br>" + "Lv. " + data.cannonFireRatelvl;
        fakeCost.text = "Cost: " + fireRateUPCost;
        if (IsMaxLevel)
        {
            fakeCost.text = "MAX LVL";
        }
    }
    public int GetCostForLevel()
    {
        float rawCost = startingCost * Mathf.Pow(1.30f, data.cannonFireRatelvl);
        return Mathf.RoundToInt(rawCost / CostStep) * CostStep;
    }
}