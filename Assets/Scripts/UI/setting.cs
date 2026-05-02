using UnityEngine;

public class setting : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject settingBG;
    public void OpenShop()
    {
        if (settingPanel.activeSelf)
        {
            settingPanel.SetActive(false);
            settingBG.SetActive(false);
        }
        else
        {
            settingPanel.SetActive(true);
            settingBG.SetActive(true);
        }

    }
}
