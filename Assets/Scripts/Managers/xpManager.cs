using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class xpManager : MonoBehaviour
{
    public Image xpBar;


    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;
    public GameObject lock5;


    public GameObject egg1;
    public GameObject egg2;
    public GameObject egg3;
    public GameObject egg4;
    public GameObject egg5;

    public GameObject shop;


    public TMP_Text lvl;
    public TMP_Text exp;


    private bool unlock1=false, unlock2=false, unlock3=false, unlock4=false, unlock5=false, unlock6=false;


    [Header("Level Up UI")]
    public GameObject levelUpPanel;
    public TMP_Text levelUpText;
    public CanvasGroup levelUpCanvas;
    void Unlock()
    {
        if (data.lvl >= 5&&!unlock1)
        {
            unlock1 = true;
            lock1.SetActive(false);
            data.maxEquippedPets = 1;
        }
        if (data.lvl >= 10 && !unlock2)
        {
            unlock2 = true;
            data.maxEquippedPets= 2;
            lock1.SetActive(false);
            lock2.SetActive(false);
        }
        if (data.lvl >= 15 && !unlock3)
        {
            unlock3 = true;
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
        }
        if (data.lvl >= 20 && !unlock4)
        {
            unlock4 = true;
            data.maxEquippedPets = 3;
        }
        if (data.lvl >= 25 && !unlock5)
        {
            unlock5 = true;
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
            lock4.SetActive(false);
        }
        if (data.lvl >= 30 && !unlock6)
        {
            unlock6 = true;
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
            lock4.SetActive(false);
            lock5.SetActive(false);
        }

            data.money += Mathf.RoundToInt(data.lvl * 50 * data.globalMoneyMod);

        if (data.lvl % 5 == 0)
        {
            data.PerkLimit++;
        }
    }
    void Start()
    {
        lock1.transform.SetParent(shop.transform);
        lock2.transform.SetParent(shop.transform);
        lock3.transform.SetParent(shop.transform);
        lock4.transform.SetParent(shop.transform);
        lock5.transform.SetParent(shop.transform);
    }

    void Update()
    {
        egg1.SetActive(unlock1);
        egg2.SetActive(unlock2);
        egg3.SetActive(unlock3);
        egg4.SetActive(unlock4);
        egg5.SetActive(unlock5);
        Debug.Log(data.maxEquippedPets);
        xpBar.fillAmount = (float)data.xp / data.xpMax;
        lvl.text = "livello:" + data.lvl;
        exp.text = data.xp + "/" + data.xpMax;

        if (data.xp >= data.xpMax)
        {
            data.xp -= data.xpMax;
            data.lvl += 1;
            Unlock();
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
