using UnityEngine;
using UnityEngine.UI;
public class ButtonPet : MonoBehaviour
{
    [SerializeField] private GameObject buttonLevelUp;
    public SuperPets pet;
    void Update()
    {
        if (buttonLevelUp != null) return;
        if (pet == null) return;

        buttonLevelUp.SetActive(pet.PuoLevelUp());
    }
    public void LevelUp()
    {
        if (pet == null) return;
        pet.ProvaLevelUp();
    }

}

