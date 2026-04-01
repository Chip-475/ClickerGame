using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class PerkManager : MonoBehaviour
{
    //crit perk
    public GameObject critPerkButton;
    public GameObject critPerkButtonFake;
    public TMP_Text headercrit;
    public TMP_Text headercritfake;
    //base click perk
    public GameObject baseClickPerkButton;
    public GameObject baseClickPerkButtonFake;
    public TMP_Text headerbaseClickPerk;
    public TMP_Text headerbaseClickPerkFake;
    public TMP_Text amountbaseClickPerk;
    public TMP_Text amountbaseClickPerkFake;
    void Update()
    {
        //crit perk
        {
            headercrit.text = "Crit Damage UP:" + data.critPerkAmount + "<br> duration:30 seconds";
            headercritfake.text = "Crit Damage UP:" + data.critPerkAmount + "<br> duration:30 seconds";
            if (data.critPerkAmount > 0)
            {
                critPerkButton.SetActive(true);
                critPerkButtonFake.SetActive(false);
            }
            else
            {
                critPerkButton.SetActive(false);
                critPerkButtonFake.SetActive(true);
            }
        }
        //click perk
        {
            amountbaseClickPerk.text = "Amount:" + data.clickPerk;
            amountbaseClickPerkFake.text = "Amount:" + data.clickPerk;
            if (data.clickPerk > 0)
            {
                baseClickPerkButton.SetActive(true);
                baseClickPerkButtonFake.SetActive(false);
            }
            else
            {
                baseClickPerkButton.SetActive(false);
                baseClickPerkButtonFake.SetActive(true);
            }
        }
    }
}
