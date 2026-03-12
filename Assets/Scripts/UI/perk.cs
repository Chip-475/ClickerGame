using UnityEngine;

public class perk : MonoBehaviour
{
    public GameObject perkPanel;
    public GameObject perkBG;
    public void OpenPerk()
    {
        if (perkPanel.activeSelf)
        {
            perkPanel.SetActive(false);
            perkBG.SetActive(false);
        }
        else
        {
            perkPanel.SetActive(true);
            perkBG.SetActive(true);
        }

    }
}
