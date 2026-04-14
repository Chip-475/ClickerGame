using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class xpManager : MonoBehaviour
{
    public Image xpBar;
    void Unlock()
    {
        switch (data.lvl)
        {
            case 5:
                //petlimit=1
                break;
            case 10:
                //perklimit=2
                break;
            case 20:
                //perklimit=3
                break;

        }
        data.money += data.lvl * 50;
        if (data.lvl % 5 == 0)
        {
            data.PerkLimit++;
        }
    }
    void Update()
    {
        xpBar.fillAmount = data.xpMax / data.xp;
        if (data.xp >= data.xpMax)
        {
            Unlock();
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