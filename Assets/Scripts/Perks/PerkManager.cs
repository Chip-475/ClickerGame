using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class PerkManager : MonoBehaviour
{
    public GameObject critPerkButton;
    public GameObject critPerkButtonFake;
    public TMP_Text header;
    public TMP_Text headerfake;
    void Update()
    {
        header.text = "Crit Damage UP:"+ data.critPerkAmount+ "<br> duration:30 seconds";
        headerfake.text = "Crit Damage UP:" + data.critPerkAmount + "<br> duration:30 seconds";
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
}
