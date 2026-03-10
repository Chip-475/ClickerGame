using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject shopBG;
    public void OpenShop()
    {
        if(shopPanel.activeSelf)
        {
            shopPanel.SetActive(false);
            shopBG.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(true);
            shopBG.SetActive(true);
        }
        
    }
}
