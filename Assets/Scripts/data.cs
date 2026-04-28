using System;
using UnityEngine;
using System.Collections.Generic;

public class data
{
    //resources
    public static int money = 100000;
    public static int PerkLimit=5;
    public static int totalPerk = 0;
    public static int meteorCrushed = 0;

    //upgrades
    public static int baseUPlvl;
    public static int critUPlvl = 0;
    public static int critDmg = 3;
    public static int meteorlvl = 1;
    public static int cannonFireRatelvl;
    public static int cannonDepotlvl;

    //exp
    public static int xp = 1;
    public static int xpMax = 10;
    public static int lvl;

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

    //pets
    public static List<PetInstance> pets= new List<PetInstance>();
    public static int maxEquippedPets = 0;
    public static float globalMoneyMod;
    public static float globalCritMod;
}
