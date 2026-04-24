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

    public float baseMoneyMod;
    public float baseCritMod;
    public int baseUPcost=100;

    public float finalMoneyMod;
    public float finalCritMod;
    public float finalUPcost;
}