using UnityEngine;

public class gachaSystem : MonoBehaviour
{
    public petDB database;
    public data data;
    public int egg;
    private void Start()
    {
        data = PetSave.Load();
    }
    public PetInstance pull()
    {
        petData pulledPet = GetPet(egg);
        PetInstance instance = new PetInstance
        {
            petName = pulledPet.petName,
            petId = System.Guid.NewGuid().ToString(),
            Petlvl = 1,
            rank = 1
        };

        data.pets.Add(instance);
        PetSave.Save(data);
        Debug.Log("pet pullato: " + instance.petName + " id pet: " + instance.petId);
        return instance;
    }
    public petData GetPet(int egg)
    {
        if (egg == 1)
        {
            Debug.Log("uovo1");
            int roll = Random.Range(0, 100);
            if (roll < 80) return getRarity(rarity.common);
            if (roll < 95) return getRarity(rarity.rare);
            if (roll <= 100) return getRarity(rarity.epic);
            return getRarity(rarity.legendary);
        }
        if (egg == 2)
        {
            Debug.Log("uovo2");
            int roll = Random.Range(0, 100);
            if (roll < 75) return getRarity(rarity.common);
            if (roll < 87) return getRarity(rarity.rare);
            if (roll < 99) return getRarity(rarity.epic);
            return getRarity(rarity.legendary);
        }
        if (egg == 3)
        {
            Debug.Log("uovo3");
            int roll = Random.Range(0, 100);
            if (roll < 65) return getRarity(rarity.common);
            if (roll < 82) return getRarity(rarity.rare);
            if (roll < 97) return getRarity(rarity.epic);
            return getRarity(rarity.legendary);
        }
        if (egg == 4)
        {
            Debug.Log("uovo4");
            int roll = Random.Range(0, 100);
            if (roll < 30) return getRarity(rarity.common);
            if (roll < 70) return getRarity(rarity.rare);
            if (roll < 95) return getRarity(rarity.epic);
            return getRarity(rarity.legendary);
        }
        if (egg == 5)
        {
            Debug.Log("uovo5");
            int roll = Random.Range(0, 100);
            if (roll < 20) return getRarity(rarity.common);
            if (roll < 60) return getRarity(rarity.rare);
            if (roll < 90) return getRarity(rarity.epic);
            return getRarity(rarity.legendary);
        }
        return null;
    }
        public petData getRarity(rarity r)
    {
        var list = new System.Collections.Generic.List<petData>();
        foreach (var p in database.allPets)
        {
            if (p.rarity == r)
            {
                list.Add(p);
            }

        }

        if (list.Count == 0) return null;

        return list[Random.Range(0, list.Count)];
    }
    public petData GetPetData(string petName)
    {
        return database.GetPetData(petName);
    }
    public void DebugInv()
    {
        foreach (var p in data.pets)
        {
            petData petInfo = GetPetData(p.petName);
            Debug.Log("inventario: petId: " + p.petId + " petName: " + p.petName + " rarity: " + petInfo.rarity);
        }
    }
    public void egg1()
    {
        egg = 1;
        pull();
        DebugInv();
    }
    public void egg2()
    {
        egg = 2;
        pull();
    }
    public void egg3()
    {
        egg = 3;
        pull();
    }
    public void egg4()
    {
        egg = 4;
        pull();
    }
    public void egg5()
    {
        egg = 5;
        pull();
    }
}
