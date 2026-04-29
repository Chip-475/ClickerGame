using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class perkManager : MonoBehaviour
{
    public TMP_Text perkCap;
    [Header("critPerk")]
    public GameObject critPerkButton;
    public GameObject critPerkButton_fake;
    public TMP_Text critPerk_amount;
    public TMP_Text critPerkFake_amount;

    [Header("clickPerk")]
    public GameObject baseClickPerkButton;
    public GameObject baseClickPerkButton_fake;
    public TMP_Text baseClickPerk_amount;
    public TMP_Text baseClickPerkFake_amount;

    [Header("clickPerk")]
    public GameObject GMPerkButton;
    public GameObject GMPerkButton_fake;
    public TMP_Text GMPerk_amount;
    public TMP_Text GMPerkFake_amount;

    [Header("autoClicker")]
    public GameObject autoClickerPerkButton;
    public GameObject autoClickerPerkButton_fake;
    public TMP_Text autoClickerPerk_amount;
    public TMP_Text autoClickerPerkFake_amount;
    void Update()
    {
        data.totalPerk = data.clickPerkAmount + data.critPerkAmount + data.goldMeteorAmount;
        perkCap.text = data.totalPerk + "/" + data.PerkLimit;
        {
            critPerk_amount.text = "Amount:" + data.critPerkAmount;
            baseClickPerkFake_amount.text = "Amount:" + data.critPerkAmount;
            if (data.critPerkAmount > 0 && !critPerk.isActive)
            {
                critPerkButton.SetActive(true);
                critPerkButton_fake.SetActive(false);
            }
            else
            {
                critPerkButton.SetActive(false);
                critPerkButton_fake.SetActive(true);
            }
        } //crit perk
        {
            baseClickPerk_amount.text = "Amount:" + data.clickPerkAmount;
            baseClickPerkFake_amount.text = "Amount:" + data.clickPerkAmount;
            if (data.clickPerkAmount > 0 && !baseClickPerk.isActive)
            {
                baseClickPerkButton.SetActive(true);
                baseClickPerkButton_fake.SetActive(false);
            }
            else
            {
                baseClickPerkButton.SetActive(false);
                baseClickPerkButton_fake.SetActive(true);
            }

        } //click perk
        {
            GMPerk_amount.text = "Amount:" + data.clickPerkAmount;
            GMPerkFake_amount.text = "Amount:" + data.clickPerkAmount;
            if (data.goldMeteorAmount > 0 && !goldMeteorPerk.isActive)
            {
                GMPerkButton.SetActive(true);
                GMPerkButton_fake.SetActive(false);
            }
            else
            {
                GMPerkButton.SetActive(false);
                GMPerkButton_fake.SetActive(true);
            }

        } //gold meteor
        {
            autoClickerPerk_amount.text = "Amount:" + data.autoclickAmount;
            autoClickerPerkFake_amount.text = "Amount:" + data.autoclickAmount;
            if (data.autoclickAmount > 0 && !baseClickPerk.isActive)
            {
                autoClickerPerkButton.SetActive(true);
                autoClickerPerkButton_fake.SetActive(false);
            }
            else
            {
                autoClickerPerkButton.SetActive(false);
                autoClickerPerkButton_fake.SetActive(true);
            }

        }
    }
}
