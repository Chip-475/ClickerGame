using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;

public class data
{
    //resources
    public static int money = 10000000;
    public static long totalMoney;
    public static int PerkLimit=5;
    public static int totalPerk = 0;
    public static int meteorCrushed = 0;
    public static int perkUsed;
    public static int totalClicks;

    //upgrades
    public static int baseUPlvl=1;
    public static int critUPlvl = 1;
    public static int critDmg = 2;
    public static int meteorlvl = 1;
    public static int cannonFireRatelvl=1;
    public static int cannonDepotlvl=1;

    //exp
    public static int xp = 0;
    public static int xpMax = 10;
    public static int lvl=1;

    //cannon management
    public static bool cannon1;
    public static bool cannon2;
    public static int fuel1=1;
    public static float fireRateReductionPerLevel;
    public static int depotBonusPerLevel;

    //perklist
    public static int critPerkAmount = 1;
    public static int clickPerkAmount = 1;
    public static int goldMeteorAmount = 1;
    public static int autoclickAmount = 1;

    //pets
    public static List<PetInstance> pets= new List<PetInstance>();
    public static int maxEquippedPets = 0;
    public static float globalMoneyMod=1;
    public static float globalCritMod;
    public static int totalOpenedEggs;

    //music
    public static float master = 1f;
    public static float music = 1f;
    public static float sfx = 1f;
}
