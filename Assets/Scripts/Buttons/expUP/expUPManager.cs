using UnityEngine;
using TMPro;

public class expUPManager : MonoBehaviour
{

    [Header("Objects")]
    public GameObject expUPbutton;
    public GameObject expUPfake;
    [Header("Texts")]
    public TMP_Text header;
    public TMP_Text cost;
    public TMP_Text effect;
    [Header("Fake Texts")]
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    public TMP_Text fake_effect;
    [Header("Stats")]
    public int expUPcost;
    public int expUPeffect;

    void Update()
    {
        if (data.money < expUPcost) { expUPbutton.SetActive(false); expUPfake.SetActive(true); }
        else { expUPbutton.SetActive(true); expUPfake.SetActive(false); }

        header.text = "Click Exp UP<br>" + "Lv. " + data.explvl;
        cost.text = "Cost: " + expUPcost;
        effect.text = "+" + expUPeffect;
        fake_header.text = "Click Exp UP<br>" + "Lv. " + data.explvl;
        fake_cost.text = "Cost: " + expUPcost;
        fake_effect.text = "+" + expUPeffect;
    }

}
