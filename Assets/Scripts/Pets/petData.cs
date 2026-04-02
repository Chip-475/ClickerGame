using System;
using UnityEngine;

[Serializable]
public struct petData
{
    public string petId;
    public string nomePet;
    public rarita raritaPet;
    [Range(0f, 100f)] public float percentuale;

    public petData(string petId, string nomePet, rarita raritaPet, float percentuale)
    {
        this.petId = petId;
        this.nomePet = nomePet;
        this.raritaPet = raritaPet;
        this.percentuale = percentuale;
    }
}
