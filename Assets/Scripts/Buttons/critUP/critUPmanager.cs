using TMPro;
using UnityEngine;

public class critUPmanager : MonoBehaviour
{
    private const int CostStep = 50;

    [Header("Objects")]
    public GameObject critUPbutton;
    public GameObject critUPfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    [Header("Stats")]
    public int critUPcost;
    public int maxLevel = 50;
    public int startingCost = 350;

    public bool IsMaxLevel = false;

    void Update()
    {
        if (data.critUPlvl >= maxLevel && !IsMaxLevel)
        {
            IsMaxLevel = true;
        }

        critUPcost = GetCostForLevel();

        if (data.money >= critUPcost && !IsMaxLevel) { critUPfake.SetActive(false); critUPbutton.SetActive(true); }
        else { critUPbutton.SetActive(false); critUPfake.SetActive(true); }

        header.text = "Crit Level UP<br>" + "Lv. " + data.critUPlvl;
        cost.text = "Cost: " + critUPcost;
        fake_header.text = "Crit Click UP<br>" + "Lv. " + data.critUPlvl;
        fake_cost.text = "Cost: " + critUPcost;
        if (IsMaxLevel)
        {
            fake_cost.text = "MAX LVL";
        }
    }

    public int GetCostForLevel()
    {
        float rawCost = startingCost * Mathf.Pow(1.35f, data.critUPlvl);
        return Mathf.RoundToInt(rawCost / CostStep) * CostStep;
    }
}
