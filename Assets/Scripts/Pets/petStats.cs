using UnityEngine;

public class petStats : MonoBehaviour
{
    [SerializeField] private petDB db;
    private int finalCost;
    public int UpgradeCost(PetInstance pet)
    {

        petData data = GetPetData(pet);
        float baseCost = data.baseUPcost;
        finalCost = (int)baseCost * ((1+(int)data.rarity)*pet.Petlvl);
        pet.currentUPcost = finalCost;

        return finalCost;
    }

    public petData GetPetData(PetInstance pet)
    {
        foreach (var p in db.allPets)
        {
            if (p.petName == pet.petName)
            {
                return p;
            }
        }

        return null;
    }
    /*private void Awake()
    {
        switch (petData.rarity)
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
    }*/
}
