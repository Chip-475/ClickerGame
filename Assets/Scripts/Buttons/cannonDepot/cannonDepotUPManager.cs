using UnityEngine;
using TMPro;
public class cannonDepotUPManager : MonoBehaviour
{
    private const int CostStep = 50;
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
    public int startingCost = 500;
    public int maxLevel = 50;
    public int depotUpCost;

    public bool IsMaxLevel =false;


    void Update()
    {
        if (data.cannonDepotlvl >= maxLevel&&!IsMaxLevel)
        {
            IsMaxLevel = true;
        }
        depotUpCost = GetCostForLevel();

        if (data.money >= depotUpCost && !IsMaxLevel && data.cannon1) { fakeButton.SetActive(false); upgradeButton.SetActive(true); }
        else { upgradeButton.SetActive(false); fakeButton.SetActive(true); }

        header.text = "Upgrade Deposit<br>" + "Lv. " + data.cannonDepotlvl;
        cost.text = "Cost: " + depotUpCost;
        fakeHeader.text = "Upgrade Deposit<br>" + "Lv. " + data.cannonDepotlvl;
        fakeCost.text = "Cost: " + depotUpCost;
        if (IsMaxLevel)
        {
            fakeCost.text = "MAX LVL";
        }
    }

    public void RefillNewCapacity()
    {
        data.fuel1 = 100 + (data.cannonDepotlvl * 10);
    }
    public int GetCostForLevel()
    {
        float rawCost = startingCost * Mathf.Pow(1.33f, data.cannonDepotlvl);
        return Mathf.RoundToInt(rawCost / CostStep) * CostStep;
    }
}