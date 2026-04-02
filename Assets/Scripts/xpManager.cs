using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class xpManager : MonoBehaviour
{
    public Image xpBar;

    void Update()
    {
        xpBar.fillAmount = data.xpMax / data.xp;
        if (data.xp >= data.xpMax)
        {
            if (data.lvl < 10)
            {
                data.xp -= data.xpMax;
                data.lvl += 1;
                data.xpMax += data.xpMax / 3;
            }
            else
            {
                data.xp -= data.xpMax;
                data.lvl += 1;
                data.xpMax = (int)(100 * Mathf.Pow(data.lvl, 1.5f));
            }
        }
    }
}