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
            headercrit.text = "Click X2:" + data.clickPerk + "<br> duration:30 seconds";
            headercritfake.text = "Click X2:" + data.clickPerk + "<br> duration:30 seconds";
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
