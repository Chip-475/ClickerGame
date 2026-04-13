using UnityEngine;
<<<<<<< Updated upstream

=======
using UnityEngine.UI;
>>>>>>> Stashed changes
public class ButtonPet : MonoBehaviour
{
    [SerializeField] private GameObject buttonLevelUp;
    public SuperPets pet;
<<<<<<< Updated upstream
    public void levelUp()
    {
        Debug.Log("SIIII");
    }
=======
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

>>>>>>> Stashed changes
}
   
