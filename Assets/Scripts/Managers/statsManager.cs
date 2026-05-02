using UnityEngine;
using TMPro;
public class statsManager : MonoBehaviour
{
    [Header("General Stuff")]
    public TMP_Text totalMoney;
    public TMP_Text currentMoney;
    public TMP_Text perkLimit;
    public TMP_Text crushedMeteor;
    public TMP_Text level;
    public TMP_Text perkUsed;
    public TMP_Text totalClicks;

    [Header("Upgrades")]
    public TMP_Text totalDMG;
    public TMP_Text critRate;

    [Header("Pets")]
    public TMP_Text moneyModifier;
    public TMP_Text critModifier;
    public TMP_Text eggsOpened;

    void Update()
    {
        totalMoney.text = data.totalMoney.ToString();
        currentMoney.text=data.money.ToString();
        perkLimit.text=data.PerkLimit.ToString();
        crushedMeteor.text=data.meteorCrushed.ToString();
        level.text=data.lvl.ToString();
        perkUsed.text=data.perkUsed.ToString();
        totalClicks.text=data.totalClicks.ToString();
        totalDMG.text=clicker.clickStr.ToString();
        critRate.text=clicker.critRate.ToString();
        moneyModifier.text=data.globalMoneyMod.ToString();
        critModifier.text=data.globalCritMod.ToString();
        eggsOpened.text=data.totalOpenedEggs.ToString();
    }
}
