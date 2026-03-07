using TMPro;
using UnityEngine;

public class critUPmanager : MonoBehaviour
{
    [Header("Objects")]
    public GameObject critUPbutton;
    public GameObject critUPfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    public TMP_Text effect;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    public TMP_Text fake_effect;
    [Header("Stats")]
    public int critUPcost;
    public int critUPeffect;

    void Update()
    {
        if (data.money < critUPcost) { critUPbutton.SetActive(false); critUPfake.SetActive(true); }
        else { critUPbutton.SetActive(true); critUPfake.SetActive(false); }

        header.text = "Crit Level UP<br>" + "Lv. " + data.critUPlvl;
        cost.text = "Cost: " + critUPcost;
        effect.text = "" + critUPeffect + "%";
        fake_header.text = "Crit Click UP<br>" + "Lv. " + data.critUPlvl;
        fake_cost.text = "Cost: " + critUPcost;
        fake_effect.text = "" + critUPeffect + "%";
    }
}
