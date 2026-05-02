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
    public TMP_Text baseUPlvl;
    public TMP_Text critRate;

    [Header("Pets")]
    public TMP_Text moneyModifier;
    public TMP_Text critModifier;
    public TMP_Text eggsOpened;

    void Update()
    {
        
    }
}
