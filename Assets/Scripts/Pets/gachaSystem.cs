using UnityEngine;

public class gachaSystem : MonoBehaviour
{
    public petDB database;
    public data data;
    public int egg;
    public static PetInstance lastPulled;
    public Egganimation eggAnim;
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
        lastPulled = instance;
        if (egg == 1) StartCoroutine(eggAnim.pullAnim(1));
        if (egg == 2) StartCoroutine(eggAnim.pullAnim(2));
        if (egg == 3) StartCoroutine(eggAnim.pullAnim(3));
        if (egg == 4) StartCoroutine(eggAnim.pullAnim(4));
        if (egg == 5) StartCoroutine(eggAnim.pullAnim(5));
        data.pets.Add(instance);
        PetSave.Save(data);
        Debug.Log("pet pullato: " + instance.petName + " id pet: " + instance.petId);
        return instance;
    }
    public petData GetPet(int egg)
    {
        data.totalOpenedEggs++;
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
    public void egg1()
    {
        if (data.money >= 500)
        {
        egg = 1;
        pull();
        data.money -= 500;
        }
        else { return; }

    }
    public void egg2()
    {
        if(data.money >= 1000)
        {
        egg = 2;
        pull();
        data.money -= 1000;
        }else { return; }

    }
    public void egg3()
    {
        if (data.money >= 1500)
        {
            egg = 3;
            pull();
            data.money -= 1500;
        }
        else { return ; }

    }
    public void egg4()
    {
        if (data.money >= 2000)
        {
            egg = 4;
            pull();
            data.money -= 2000;
        }else { return ; }

    }
    public void egg5()
    {
        if (data.money >= 5000)
        {
            egg = 5;
            pull();
            data.money -= 5000;
        }else { return ; }

    }
}
