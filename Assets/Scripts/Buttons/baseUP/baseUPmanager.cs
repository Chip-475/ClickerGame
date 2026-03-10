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
    public int baseUPcost;
    public int baseUPeffect;

    void Update()
    {
        if (data.money < baseUPcost) { baseUPbutton.SetActive(false); baseUPfake.SetActive(true); }
        else { baseUPbutton.SetActive(true); baseUPfake.SetActive(false); }

        header.text = "Base Click UP<br>" + "Lv. " + data.explvl;
        cost.text = "Cost: " + baseUPcost;
        effect.text = "" + baseUPeffect;
        fake_header.text = "Base Click UP<br>" + "Lv. " + data.explvl;
        fake_cost.text = "Cost: " + baseUPcost;
        fake_effect.text = "" + baseUPeffect;
    }

}
