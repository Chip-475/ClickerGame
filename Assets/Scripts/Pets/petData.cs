using System;
using UnityEngine;

[Serializable]
public enum Rarita1
{
    Common,
    Rare,
    Leggend
}
[Serializable]
public struct petData
{
    public string petId;
    public string nomePet;
    public Rarita1 raritaPet;
    [Range(0f, 100f)] public float percentuale;

    public petData(string petId, string nomePet, Rarita1 raritaPet, float percentuale)
    {
        this.petId = petId;
        this.nomePet = nomePet;
        this.raritaPet = raritaPet;
        this.percentuale = percentuale;
    }
}