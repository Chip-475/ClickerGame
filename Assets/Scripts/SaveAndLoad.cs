using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    private static SaveAndLoad instance;
    private static readonly string SavePath = Path.Combine(Application.persistentDataPath, "save.json");
    private static bool hasLoaded;

    [SerializeField] private float autoSaveInterval = 5f;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        if (instance != null)
        {
            return;
        }

        GameObject saveObject = new GameObject("SaveAndLoad");
        instance = saveObject.AddComponent<SaveAndLoad>();
        DontDestroyOnLoad(saveObject);
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNow();
        StartCoroutine(AutoSaveLoop());
    }

    private IEnumerator AutoSaveLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveInterval);
            SaveNow();
        }
    }

    private void OnApplicationQuit()
    {
        SaveNow();
    }

    public static void SaveNow()
    {
        SaveFileData saveData = new SaveFileData
        {
            money = data.money,
            totalMoney = data.totalMoney,
            perkLimit = data.PerkLimit,
            totalPerk = data.totalPerk,
            meteorCrushed = data.meteorCrushed,
            perkUsed = data.perkUsed,
            totalClicks = data.totalClicks,
            baseUPlvl = data.baseUPlvl,
            critUPlvl = data.critUPlvl,
            critDmg = data.critDmg,
            meteorlvl = data.meteorlvl,
            cannonFireRatelvl = data.cannonFireRatelvl,
            cannonDepotlvl = data.cannonDepotlvl,
            xp = data.xp,
            xpMax = data.xpMax,
            lvl = data.lvl,
            cannon1 = data.cannon1,
            cannon2 = data.cannon2,
            fuel1 = data.fuel1,
            fireRateReductionPerLevel = data.fireRateReductionPerLevel,
            depotBonusPerLevel = data.depotBonusPerLevel,
            critPerkAmount = data.critPerkAmount,
            clickPerkAmount = data.clickPerkAmount,
            goldMeteorAmount = data.goldMeteorAmount,
            autoclickAmount = data.autoclickAmount,
            maxEquippedPets = data.maxEquippedPets,
            globalMoneyMod = data.globalMoneyMod,
            globalCritMod = data.globalCritMod,
            totalOpenedEggs = data.totalOpenedEggs,
            master = data.master,
            music = data.music,
            sfx = data.sfx,
            clickStr = clicker.clickStr,
            clickExp = clicker.clickExp,
            pets = new List<PetInstance>(data.pets)
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(SavePath, json);
    }

    public static void LoadNow()
    {
        if (!File.Exists(SavePath))
        {
            hasLoaded = true;
            if (data.pets == null)
            {
                data.pets = new List<PetInstance>();
            }
            return;
        }

        string json = File.ReadAllText(SavePath);
        SaveFileData saveData = JsonUtility.FromJson<SaveFileData>(json);

        if (saveData == null)
        {
            Debug.LogWarning("Save file is empty or invalid.");
            return;
        }

        data.money = saveData.money;
        data.totalMoney = saveData.totalMoney;
        data.PerkLimit = saveData.perkLimit;
        data.totalPerk = saveData.totalPerk;
        data.meteorCrushed = saveData.meteorCrushed;
        data.perkUsed = saveData.perkUsed;
        data.totalClicks = saveData.totalClicks;
        data.baseUPlvl = saveData.baseUPlvl;
        data.critUPlvl = saveData.critUPlvl;
        data.critDmg = saveData.critDmg;
        data.meteorlvl = saveData.meteorlvl;
        data.cannonFireRatelvl = saveData.cannonFireRatelvl;
        data.cannonDepotlvl = saveData.cannonDepotlvl;
        data.xp = saveData.xp;
        data.xpMax = saveData.xpMax;
        data.lvl = saveData.lvl;
        data.cannon1 = saveData.cannon1;
        data.cannon2 = saveData.cannon2;
        data.fuel1 = saveData.fuel1;
        data.fireRateReductionPerLevel = saveData.fireRateReductionPerLevel;
        data.depotBonusPerLevel = saveData.depotBonusPerLevel;
        data.critPerkAmount = saveData.critPerkAmount;
        data.clickPerkAmount = saveData.clickPerkAmount;
        data.goldMeteorAmount = saveData.goldMeteorAmount;
        data.autoclickAmount = saveData.autoclickAmount;
        data.maxEquippedPets = saveData.maxEquippedPets;
        data.globalMoneyMod = saveData.globalMoneyMod <= 0 ? 1f : saveData.globalMoneyMod;
        data.globalCritMod = saveData.globalCritMod;
        data.totalOpenedEggs = saveData.totalOpenedEggs;
        data.master = saveData.master;
        data.music = saveData.music;
        data.sfx = saveData.sfx;
        clicker.clickStr = saveData.clickStr <= 0 ? 1 : saveData.clickStr;
        clicker.clickExp = saveData.clickExp <= 0 ? 10 : saveData.clickExp;
        data.pets = saveData.pets ?? new List<PetInstance>();

        hasLoaded = true;
    }

    public static bool HasLoaded()
    {
        return hasLoaded;
    }

    public static void ResetAllData(bool reloadScene = true)
    {
        data.money = 0;
        data.totalMoney = 0;
        data.PerkLimit = 5;
        data.totalPerk = 0;
        data.meteorCrushed = 0;
        data.perkUsed = 0;
        data.totalClicks = 0;

        data.baseUPlvl = 1;
        data.critUPlvl = 1;
        data.critDmg = 2;
        data.meteorlvl = 1;
        data.cannonFireRatelvl = 1;
        data.cannonDepotlvl = 1;

        data.xp = 0;
        data.xpMax = 10;
        data.lvl = 1;

        data.cannon1 = false;
        data.cannon2 = false;
        data.fuel1 = 1;
        data.fireRateReductionPerLevel = 0f;
        data.depotBonusPerLevel = 0;

        data.critPerkAmount = 1;
        data.clickPerkAmount = 1;
        data.goldMeteorAmount = 1;
        data.autoclickAmount = 1;

        data.pets = new List<PetInstance>();
        data.maxEquippedPets = 0;
        data.globalMoneyMod = 1f;
        data.globalCritMod = 0f;
        data.totalOpenedEggs = 0;

        data.master = 1f;
        data.music = 1f;
        data.sfx = 1f;

        clicker.clickStr = 1;
        clicker.clickExp = 10;
        clicker.critRate = 0;
        clicker.autoClicker = false;

        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
        }

        SaveNow();

        if (reloadScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

[Serializable]
public class SaveFileData
{
    public int money;
    public long totalMoney;
    public int perkLimit;
    public int totalPerk;
    public int meteorCrushed;
    public int perkUsed;
    public int totalClicks;
    public int baseUPlvl;
    public int critUPlvl;
    public int critDmg;
    public int meteorlvl;
    public int cannonFireRatelvl;
    public int cannonDepotlvl;
    public int xp;
    public int xpMax;
    public int lvl;
    public bool cannon1;
    public bool cannon2;
    public int fuel1;
    public float fireRateReductionPerLevel;
    public int depotBonusPerLevel;
    public int critPerkAmount;
    public int clickPerkAmount;
    public int goldMeteorAmount;
    public int autoclickAmount;
    public int maxEquippedPets;
    public float globalMoneyMod;
    public float globalCritMod;
    public int totalOpenedEggs;
    public float master;
    public float music;
    public float sfx;
    public int clickStr;
    public int clickExp;
    public List<PetInstance> pets = new List<PetInstance>();
}
