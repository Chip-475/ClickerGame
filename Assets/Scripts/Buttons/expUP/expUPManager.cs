using UnityEngine;
using TMPro;

public class expUPManager : MonoBehaviour
{
    private const int CostStep = 50;

    [Header("Objects")]
    public GameObject expUPbutton;
    public GameObject expUPfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    [Header("Stats")]
    public int expUPcost;
    public int maxLevel = 50;
    public int startingCost = 300;

    public bool IsMaxLevel = false;

    void Update()
    {
        if (data.lvl >= maxLevel && !IsMaxLevel)
        {
            IsMaxLevel = true;
        }

        expUPcost = GetCostForLevel();

        if (data.money >= expUPcost && !IsMaxLevel) { expUPfake.SetActive(false); expUPbutton.SetActive(true); }
        else { expUPbutton.SetActive(false); expUPfake.SetActive(true); }

        header.text = "Click Exp UP<br>" + "Lv. " + data.lvl;
        cost.text = "Cost: " + expUPcost;
        fake_header.text = "Click Exp UP<br>" + "Lv. " + data.lvl;
        fake_cost.text = "Cost: " + expUPcost;
        if (IsMaxLevel)
        {
            fake_cost.text = "MAX LVL";
        }
    }

    public int GetCostForLevel()
    {
        float rawCost = startingCost * Mathf.Pow(1.34f, data.lvl);
        return Mathf.RoundToInt(rawCost / CostStep) * CostStep;
    }
}
