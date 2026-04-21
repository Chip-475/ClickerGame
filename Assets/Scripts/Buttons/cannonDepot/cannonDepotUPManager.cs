using UnityEngine;
using TMPro;
public class cannonDepotUPManager : MonoBehaviour
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
    public int[] levelCosts = { 200, 500, 1000, 2500, 5000 };
    public cannonManager cannonManager;

    public int CurrentCost
    {
        get
        {
            if (data.cannonDepotlvl >= levelCosts.Length)
            {
                return -1;
            }
            return levelCosts[data.cannonDepotlvl];
        }
    }

    public bool IsMaxLevel => data.cannonDepotlvl >= levelCosts.Length;


    void Update()
    {
        bool canBuy = !IsMaxLevel && data.money >= CurrentCost;

        if (upgradeButton != null) upgradeButton.SetActive(canBuy);
        if (fakeButton != null) fakeButton.SetActive(!canBuy);

        int depotValue = cannonManager != null ? cannonManager.depotBonusPerLevel : 0;

        string headerText = "Cannon Depot UP<br>Lv. " + data.cannonDepotlvl;
        string costText = IsMaxLevel ? "MAX" : "Cost: " + CurrentCost;
        string effectText = "+" + depotValue + " cap";

        if (header != null) header.text = headerText;
        if (cost != null) cost.text = costText;
        if (effect != null) effect.text = effectText;

        if (fakeHeader != null) fakeHeader.text = headerText;
        if (fakeCost != null) fakeCost.text = costText;
        if (fakeEffect != null) fakeEffect.text = effectText;
    }

    public void RefillNewCapacity()
    {
        if (cannonManager == null)
        {
            return;

        }

        data.fuel1 = 100 + (data.cannonDepotlvl * 10);
        data.fuel2 = 100 + (data.cannonDepotlvl * 10);
    }
}

