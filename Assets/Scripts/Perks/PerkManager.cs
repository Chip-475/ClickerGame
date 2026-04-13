using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class perkManager : MonoBehaviour
{
    [Header("critPerk")]
    public GameObject critPerkButton;
    public GameObject critPerkButton_fake;
    public TMP_Text headercrit;
    public TMP_Text headercrit_fake;
    [Header("clickPerk")]
    public GameObject baseClickPerkButton;
    public GameObject baseClickPerkButton_fake;
    public TMP_Text baseClickPerk_header;
    public TMP_Text baseClickPerkFake_header;
    public TMP_Text baseClickPerk_amount;
    public TMP_Text baseClickPerkFake_amount;
    void Update()
    {

        {
            headercrit.text = "Crit Damage UP:" + data.critPerkAmount + "<br> duration:30 seconds";
            headercrit_fake.text = "Crit Damage UP:" + data.critPerkAmount + "<br> duration:30 seconds";
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
            baseClickPerk_amount.text = "Amount:" + data.clickPerk;
            baseClickPerkFake_amount.text = "Amount:" + data.clickPerk;
            if (data.clickPerk > 0 && !baseClickPerk.isActive)
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
    }
}