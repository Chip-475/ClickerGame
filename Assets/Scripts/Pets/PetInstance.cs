using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class PetInstance 
{
    [FormerlySerializedAs("petID")]
    public string petId;
    public string petName;
    public int rank;
    public int Petlvl;

    public float currentMoneyMod;
    public float currentCritMod;
    public float currentUPcost;
}
