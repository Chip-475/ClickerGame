using UnityEngine;
using TMPro;

public class baseUPmanager : MonoBehaviour
{

    [Header("Objects")]
    public GameObject baseUPbutton;
    public GameObject baseUPfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    public TMP_Text effect;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    public TMP_Text fake_effect;
    [Header("Stats")]
    public int baseUPlvl;
    public int baseUPcost;
    public int baseUPeffect;

    void Update()
    {
        if (data.money < baseUPcost) { baseUPbutton.SetActive(false); baseUPfake.SetActive(true); }
        else { baseUPbutton.SetActive(true); baseUPfake.SetActive(false); }

        if (baseUPlvl > 0) data.baseUP = true;
        else data.baseUP = false;

        header.text = "Base Click UP<br>" + "Lv. " + baseUPlvl;
        cost.text = "Cost: " + baseUPcost;
        effect.text = "" + baseUPeffect;
        fake_header.text = "Base Click UP<br>" + "Lv. " + baseUPlvl;
        fake_cost.text = "Cost: " + baseUPcost;
        fake_effect.text = "" + baseUPeffect;
    }
}
