using UnityEngine;
using UnityEngine.UI;

public class xpBar : MonoBehaviour
{
    public Image xpmBar;
    void UpdateBar()
    {
        xpmBar.fillAmount = data.exp / data.maxXp;
    }

    void Update()
    {
       UpdateBar();

    }
}