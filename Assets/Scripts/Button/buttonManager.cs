using UnityEngine;
using TMPro;
public class buttonManager : MonoBehaviour
{
    [Header("Objects")] // piccola 
    public GameObject baseUPbutton;
    public GameObject baseUPfake;
    [Header("Texts")] //per settare la parte grafica vero
    public TMP_Text header;
    public TMP_Text cost;
    public TMP_Text effect;
    [Header("Fake Texts")]  //per settare la parte grafica del falso
    public TMP_Text fake_header;
    public TMP_Text fake_cost;
    public TMP_Text fake_effect;
    [Header("Stats")]  // statistiche 
    public int baseUPcost;
    public int baseUPeffect;
    
    void Update()
    {
        if (data.money < baseUPcost) { baseUPbutton.SetActive(false); baseUPfake.SetActive(true); }  // se ho i soldi lo posso cliccare se no
        else { baseUPbutton.SetActive(true); baseUPfake.SetActive(false); }

        header.text = "Base Click UP<br>" + "Lv. " + data.baseUPlvl;   // scrivo le stats
        cost.text = "Cost: " + baseUPcost;
        effect.text = "" + baseUPeffect;
        fake_header.text = "Base Click UP<br>" + "Lv. " + data.baseUPlvl;
        fake_cost.text = "Cost: " + baseUPcost;
        fake_effect.text = "" + baseUPeffect;
    }
}
