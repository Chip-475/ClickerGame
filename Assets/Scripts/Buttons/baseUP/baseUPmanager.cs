using UnityEngine;
using TMPro;

public class baseUPmanager : MonoBehaviour
{
    private const int CostStep = 50;

    [Header("Objects")]
    public GameObject baseUPbutton;
    public GameObject baseUPfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    [Header("Stats")]
    public int baseUPcost;
    public int maxLevel = 50;
    public int startingCost = 250;

    public bool IsMaxLevel=false;

    void Update()
    {
        if (data.baseUPlvl >= maxLevel&&!IsMaxLevel)
        {
            IsMaxLevel = true;
        }
        baseUPcost = GetCostForLevel();

        if (data.money >= baseUPcost&&!IsMaxLevel) { baseUPfake.SetActive(false); baseUPbutton.SetActive(true); }
        else { baseUPfake.SetActive(true); baseUPbutton.SetActive(false); }

        header.text = "Base Click UP<br>" + "Lv. " + data.baseUPlvl;
        cost.text ="Cost: " + baseUPcost;
        fake_header.text = "Base Click UP<br>" + "Lv. " + data.baseUPlvl;
        fake_cost.text ="Cost: " + baseUPcost;
        if(IsMaxLevel)
        {
            fake_cost.text = "MAX LVL";
        }
    }

    public int GetCostForLevel()
    {
        float rawCost = 250f * Mathf.Pow(1.32f, data.baseUPlvl);
        return Mathf.RoundToInt(rawCost / CostStep) * CostStep;
    }
}
