using System;
using System.Collections;
using System.IO;
using UnityEngine;

/*public class SaveAndLoad : MonoBehaviour
{
    IEnumerator autoSave()
    {
        SaveData();
        yield return new WaitForSeconds(5);
        StartCoroutine(autoSave());
    }

    void Start()
    {
        LoadData();
        StartCoroutine(autoSave());
    }

    void SaveData()
    {
        SaveData inv = new SaveData();

        inv.money = data.money;
        inv.critMoney = data.critMoney;

        inv.baseUPlvl = data.baseUPlvl;
        inv.critUPlvl = data.critUPlvl;
        inv.critDmg = data.critDmg;
        inv.meteorlvl = data.meteorlvl;

        inv.xp = data.xp;
        inv.xpMax = data.xpMax;
        inv.lvl = data.lvl;

        inv.fuel1 = data.fuel1;
        inv.fuel2 = data.fuel2;

        inv.critPerkAmount = data.critPerkAmount;
        inv.clickPerk = data.clickPerk;
        inv.goldMeteor = data.goldMeteor;

        string json = JsonUtility.ToJson(inv);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log("Writing file to: " + Application.persistentDataPath);
    }

    void LoadData()
    {
        SaveData inv = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.persistentDataPath + "/save.json"));

        data.money = inv.money;
        data.critMoney = inv.critMoney;

        data.baseUPlvl = inv.baseUPlvl;
        data.critUPlvl = inv.critUPlvl;
        data.critDmg = inv.critDmg;
        data.meteorlvl = inv.meteorlvl;

        data.xp = inv.xp;
        data.xpMax = inv.xpMax;
        data.lvl = inv.lvl;

        data.fuel1 = inv.fuel1;
        data.fuel2 = inv.fuel2;

        data.critPerkAmount = inv.critPerkAmount;
        data.clickPerk = inv.clickPerk;
        data.goldMeteor = inv.goldMeteor;
    }
}

[Serializable]
public class SaveData
{
    //resources
    public int money;
    public int critMoney;

    //upgrades
    public int baseUPlvl;
    public int critUPlvl;
    public int critDmg;
    public int meteorlvl;

    //exp
    public int xp;
    public int xpMax;
    public int lvl;

    //cannon management
    public int fuel1;
    public int fuel2;

    //perklist
    public int critPerkAmount;
    public int clickPerk;
    public int goldMeteor;
}*/
