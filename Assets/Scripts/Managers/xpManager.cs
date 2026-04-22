using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class xpManager : MonoBehaviour
{
    public Image xpBar;
    public TMP_Text lvl;
    public TMP_Text exp;
    [Header("Level Up UI")]
    public GameObject levelUpPanel;
    public TMP_Text levelUpText;
    public CanvasGroup levelUpCanvas;
    void Unlock()
    {
        switch (data.lvl)
        {
            case 5:
                break;
            case 10:
                break;
            case 20:
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
        xpBar.fillAmount = (float)data.xp / data.xpMax;
        lvl.text = "livello:" + data.lvl;
        exp.text = data.xp + "/" + data.xpMax;

        if (data.xp >= data.xpMax)
        {
            Unlock();

            data.xp -= data.xpMax;
            data.lvl += 1;

            if (data.lvl < 10)
                data.xpMax += data.xpMax / 3;
            else
                data.xpMax = (int)(100 * Mathf.Pow(data.lvl, 1.5f));
            StartCoroutine(LevelUpAnimation());
        }
    }

    IEnumerator LevelUpAnimation()
    {
        levelUpPanel.SetActive(true);
        RectTransform rect = levelUpPanel.GetComponent<RectTransform>();
        
        if (data.lvl % 5 == 0)
        {
            if(data.lvl!=5&&data.lvl!=10&&data.lvl!=20) levelUpText.text = "Level: " + data.lvl + "<br>Obtained:" + data.lvl * 50+"<br>New Perk Cap:"+data.PerkLimit;
            switch (data.lvl)
            {
                case 5:
                    levelUpText.text = "Level: " + data.lvl + "<br>Obtained:" + data.lvl * 50 + "<br>New Perk Cap:" + data.PerkLimit + "<br>Pet Unlocked";
                    break;
                case 10:
                    levelUpText.text = "Level: " + data.lvl + "<br>Obtained:" + data.lvl * 50 + "<br>New Perk Cap:" + data.PerkLimit + "<br>2nd Pet Slot Unlocked";
                    break;
                case 20:
                    levelUpText.text = "Level: " + data.lvl + "<br>Obtained:" + data.lvl * 50 + "<br>New Perk Cap:" + data.PerkLimit + "<br>3rd Pet Slot Unlocked";
                    break;
            }
        }//text handling
        else
        {
            levelUpText.text = "Level: " + data.lvl+"<br>Obtained:"+data.lvl*50;
        }
        float duration = 0.3f;
        float t = 0;
        rect.localScale = Vector3.zero;
        levelUpCanvas.alpha = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;
            rect.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, progress);
            levelUpCanvas.alpha = progress;
            yield return null;
        }
        yield return new WaitForSeconds(0.8f);
        t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;
            levelUpCanvas.alpha = 1 - progress;
            yield return null;
        }

        levelUpPanel.SetActive(false);
    }
}