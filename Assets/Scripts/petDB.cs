using UnityEngine;

[CreateAssetMenu(fileName = "PetDatabase", menuName = "Game/Pet Database")]
public class petDB : ScriptableObject
{
    public petData[] allPets;

    public petData GetPetData(string petName)
    {
        if (allPets == null) return null;

        foreach (petData pet in allPets)
        {
            if (pet != null && pet.petName == petName)
            {
                return pet;
            }
        }

        return null;
    }
}
