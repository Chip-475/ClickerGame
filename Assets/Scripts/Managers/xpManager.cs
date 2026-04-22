using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class xpManager : MonoBehaviour
{
    public Image xpBar;
    public TMP_Text lvl;
    public TMP_Text exp;
    void Unlock()
    {
        switch (data.lvl)
        {
            case 5:
                //petlimit=1
                break;
            case 10:
                //petlimit=2
                break;
            case 20:
                //petlimit=3
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
        xpBar.fillAmount = (float)data.xp/ data.xpMax;
        lvl.text = "livello:"+data.lvl;
        exp.text = data.xp+"/"+data.xpMax;
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