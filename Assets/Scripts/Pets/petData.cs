using System;
using UnityEngine;

public enum rarity
{
    common,
    rare,
    epic,
    legendary
}

[CreateAssetMenu(fileName = "NewPet", menuName = "Game/Pet")]
public class petData : ScriptableObject
{
    public string id;

    public string petName;
    public Sprite sprite;
    public rarity rarity;

    public int lvl;
    public int rank;

    public float baseMoneyMod;
    public float baseCritMod;
    public float baseUPcost;

    public float finalMoneyMod;
    public float finalCritMod;
    public float finalUPcost;

    private void Awake()
    {
        Math.Clamp(lvl, 1, 10);
        Math.Clamp(rank, 1, 5);
        switch (rarity)
        {
            case rarity.common:
                baseMoneyMod = 1.1f;
                baseCritMod = 0.1f;
                finalUPcost = 50;
                break;
            case rarity.rare:
                baseMoneyMod = 1.25f;
                baseCritMod = 0.25f;
                finalUPcost = 250;
                break;
            case rarity.epic:
                baseMoneyMod = 1.5f;
                baseCritMod = 0.5f;
                finalUPcost = 500;
                break;
            case rarity.legendary:
                baseMoneyMod = 2f;
                baseCritMod = 1f;
                finalUPcost = 1000;
                break;
        }
        Debug.Log("Pet Created");
    }
}