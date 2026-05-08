using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class xpManager : MonoBehaviour
{
    public Image xpBar;
    public AudioClip lvlupSFX;
    public Color gray;

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

    public Image egg1Img;
    public Image egg2Img;
    public Image egg3Img;
    public Image egg4Img;
    public Image egg5Img;

    public Button egg1Btn;
    public Button egg2Btn;
    public Button egg3Btn;
    public Button egg4Btn;
    public Button egg5Btn;

    public GameObject shop;


    public TMP_Text lvl;
    public TMP_Text exp;
    public bool lvlup;

    private bool unlock1 = false, unlock2 = false, unlock3 = false, unlock4 = false, unlock5 = false;


    [Header("Level Up UI")]
    public GameObject levelUpPanel;
    public TMP_Text levelUpText;
    public CanvasGroup levelUpCanvas;
    void Unlock()
    {
        if (data.lvl >= 5 && !unlock1)
        {
            unlock1 = true;
            lock1.SetActive(false);
            data.maxEquippedPets = 1;
        }
        if (data.lvl >= 10 && !unlock2)
        {
            unlock2 = true;
            data.maxEquippedPets = 2;
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
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
            lock4.SetActive(false);
            data.maxEquippedPets = 3;
        }
        if (data.lvl >= 30 && !unlock5)
        {
            unlock5 = true;
            lock1.SetActive(false);
            lock2.SetActive(false);
            lock3.SetActive(false);
            lock4.SetActive(false);
            lock5.SetActive(false);
        }
        if (lvlup)
        {
            data.money += Mathf.RoundToInt(data.lvl * 50 * data.globalMoneyMod);
            data.totalMoney += Mathf.RoundToInt(data.lvl * 50 * data.globalMoneyMod);
            if (data.lvl % 5 == 0)
            {
                data.PerkLimit++;
            }
            lvlup= false;
        }

    }
    void Start()
    {
        Unlock();
        ColorUtility.TryParseHtmlString("#5A5A5A", out gray);
        lock1.transform.SetParent(shop.transform);
        lock2.transform.SetParent(shop.transform);
        lock3.transform.SetParent(shop.transform);
        lock4.transform.SetParent(shop.transform);
        lock5.transform.SetParent(shop.transform);
        egg1Img = egg1.GetComponent<Image>();
        egg2Img = egg2.GetComponent<Image>();
        egg3Img = egg3.GetComponent<Image>();
        egg4Img = egg4.GetComponent<Image>();
        egg5Img = egg5.GetComponent<Image>();
        egg1Btn = egg1.GetComponent<Button>();
        egg2Btn = egg2.GetComponent<Button>();
        egg3Btn = egg3.GetComponent<Button>();
        egg4Btn = egg4.GetComponent<Button>();
        egg5Btn = egg5.GetComponent<Button>();
    }

    void Update()
    {
        if (data.money < 5000 || !unlock1 || Egganimation.isPulling)
        {
            egg1Img.color = gray;
            egg1Btn.interactable = false;
        }
        else
        {
            egg1Img.color = Color.white;
            egg1Btn.interactable= true;
        }
        if (data.money < 10000 || !unlock2 || Egganimation.isPulling)
        {
            egg2Img.color = gray;
            egg2Btn.interactable = false;
        }
        else
        {
            egg2Img.color = Color.white;
            egg2Btn.interactable= true;
        }
        if (data.money < 25000 || !unlock3 || Egganimation.isPulling)
        {
            egg3Img.color = gray;
            egg3Btn.interactable = false;
        }
        else
        {
            egg3Img.color = Color.white;
            egg3Btn.interactable= true;
        }
        if (data.money < 50000 || !unlock4 || Egganimation.isPulling)
        {
            egg4Img.color = gray;
            egg4Btn.interactable = false;
        }
        else
        {
            egg4Img.color = Color.white;
            egg4Btn.interactable= true;
        }
        if (data.money < 100000 || !unlock5 || Egganimation.isPulling)
        {
            egg5Img.color = gray;
            egg5Btn.interactable = false;
        }
        else
        {
            egg5Img.color = Color.white;
            egg5Btn.interactable= true;
        }

        Debug.Log(data.maxEquippedPets);
        xpBar.fillAmount = (float)data.xp / data.xpMax;
        lvl.text = "level:" + data.lvl;
        exp.text = data.xp + "/" + data.xpMax;

        if (data.xp >= data.xpMax)
        {
            data.xp -= data.xpMax;
            data.lvl += 1;
            lvlup = true;
            Unlock();
            data.xpMax = Mathf.RoundToInt(35f * Mathf.Pow(data.lvl, 1.65f));
            StartCoroutine(LevelUpAnimation());
        }
    }

    IEnumerator LevelUpAnimation()
    {
        levelUpPanel.SetActive(true);
        RectTransform rect = levelUpPanel.GetComponent<RectTransform>();
        audioManager.manager.playSFX(lvlupSFX, transform, data.sfx);
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
