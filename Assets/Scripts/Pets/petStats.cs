using UnityEngine;

public class petStats : MonoBehaviour
{
    [SerializeField] private petDB db;
    private int finalCost;
    private void Start()
    {
        getGlobalBonus();
    }
    private void Update()
    {
        data.globalCritMod = Mathf.Clamp(data.globalCritMod, 0, 25);
    }

    public int UpgradeCost(PetInstance pet)
    {
        if (pet == null)
        {
            return 0;
        }

        int rarityValue=getRarity(pet);
        float rarityMult = 1f + rarityValue * 0.60f;
        float rankMult = 1f + (Mathf.Max(1, pet.rank) - 1) * 0.35f;
        float lvlGrowth=Mathf.Pow(Mathf.Max(1, pet.Petlvl), 1.18f);
        petData petData = GetPetData(pet);
        float baseCost =100f;
        finalCost =Mathf.RoundToInt(baseCost*rarityMult*rankMult*lvlGrowth/10f)*10;
        pet.currentUPcost = finalCost;

        return finalCost;
    }

    public petData GetPetData(PetInstance pet)
    {
        if (pet == null)
        {
            return null;
        }

        if (db == null || db.allPets == null)
        {
            return null;
        }

        foreach (var p in db.allPets)
        {
            if (p != null && p.petName == pet.petName)
            {
                return p;
            }
        }

        return null;
    }
    public Sprite getSprite(PetInstance pet)
    {
        if (db == null || db.allPets == null || pet == null)
        {
            return null;
        }

        foreach (var p in db.allPets)
        {
            if (p != null && p.petName == pet.petName)
            {
                return p.sprite;
            }

        }
        return null;
    }
    public int getMaxlvl(PetInstance pet)
    {
        if (pet == null)
        {
            return 10;
        }

        return 10 * Mathf.Max(1, pet.rank);
    }
    public int getLvl(PetInstance pet)
    {
        if (pet == null)
        {
            return 1;
        }

        return pet.Petlvl;
    }
    public int getRarity(PetInstance pet)
    {
        petData petData = GetPetData(pet);
        if (petData == null)
        {
            return (int)rarity.common;
        }

        return (int)petData.rarity;
    }
    public float getCritBonus(PetInstance pet)
    {
        if (pet == null)
        {
            return 0f;
        }

        float progress=Mathf.Clamp01((Mathf.Max(1, pet.Petlvl)-1f)/(getMaxlvl(pet) - 1f));
        int ratityValue = getRarity(pet);
        return progress * (7f + ratityValue * 6f);
    }
    public float getMoneyBonus(PetInstance pet)
    {
        if (pet == null)
        {
            return 1f;
        }

        float progress = Mathf.Clamp01((Mathf.Max(1, pet.Petlvl) - 1f) / (getMaxlvl(pet) - 1f));
        int rarityValue = getRarity(pet);
        float rarityBonus = 0.40f + rarityValue * 0.40f;
        float rankBonus = 1f + (Mathf.Max(1, pet.rank) - 1) * 0.375f;
        return 1f + rankBonus * progress * rarityBonus;
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
