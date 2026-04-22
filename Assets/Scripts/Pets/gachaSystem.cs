using UnityEngine;

public class gachaSystem : MonoBehaviour
{
    public petDB database;
    public data data;
    public PetInstance pull()
    {
        petData pulledPet = GetPet();
        PetInstance instance = new PetInstance
        {
            petID = pulledPet.id,
            Petlvl=1,
            rank=1
        };
        data.pets.Add(instance);
        PetSave.Save(data);
        return instance;
    }
    petData GetPet()
    {
       //gacha system
    }
}
