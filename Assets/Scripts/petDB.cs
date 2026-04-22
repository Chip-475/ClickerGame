using UnityEngine;

[CreateAssetMenu(fileName = "PetDatabase", menuName = "Game/Pet Database")]
public class petDB : ScriptableObject
{
    public petData[] allPets;
}
