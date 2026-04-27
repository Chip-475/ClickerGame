using UnityEngine;

public class petStats : MonoBehaviour
{
    [SerializeField] private petDB db;
    private int finalCost;
    private void Start()
    {
        getGlobalBonus();
    }

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
    public int getMaxlvl(PetInstance pet)
    {
        return 10 * pet.rank;
    }
    public int getLvl(PetInstance pet)
    {
        return pet.Petlvl;
    }
    public int getRarity(PetInstance pet)
    {
        petData data = GetPetData(pet);
        return (int)data.rarity;
    }
    public float getCritBonus(PetInstance pet)
    {
        float progress=(pet.Petlvl-1f)/(getMaxlvl(pet));
        int ratityValue = getRarity(pet);
        return progress * (7f + ratityValue * 6f);
    }
    public float getMoneyBonus(PetInstance pet)
    {
        float progress = (pet.Petlvl - 1f) / (getMaxlvl(pet));
        int ratityValue = getRarity(pet);
        return 1f+progress * (1f + ratityValue);
    }

    public int GetEquippedPetCount()
    {
        int equippedCount = 0;
        foreach (var pet in data.pets)
        {
            if (pet.isEquipped)
            {
                equippedCount++;
            }
        }

        return equippedCount;
    }

    public bool CanEquip(PetInstance pet)
    {
        return !pet.isEquipped && GetEquippedPetCount() < data.maxEquippedPets;
    }

    public void getGlobalBonus()
    {
        data.globalMoneyMod = 1f;
        data.globalCritMod = 0f;

        foreach (var pet in data.pets)
        {
            pet.currentMoneyMod = getMoneyBonus(pet);
            pet.currentCritMod = getCritBonus(pet);

            if (!pet.isEquipped)
            {
                continue;
            }

            data.globalMoneyMod *= pet.currentMoneyMod;
            data.globalCritMod += pet.currentCritMod;
        }
    }
    public int getSellValue(PetInstance pet)
    {
        return (getRarity(pet) + 1) * pet.rank + (pet.Petlvl * 10);
    }
}
