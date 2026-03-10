using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject shopPanel;
    public void OpenShop()
    {
        if(shopPanel.activeSelf)
        {
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(true);
        }
        
    }
}
