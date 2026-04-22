using UnityEngine;
using UnityEngine.UI;
public class ButtonPet : MonoBehaviour
{
    [SerializeField] private GameObject buttonLevelUp;
    public SottoPet pet;
    void Update()
    {
        if (buttonLevelUp==null) return;
        if (pet==null) return;
        buttonLevelUp.SetActive(true);
    }
    public void LevelUp()
    {
        Debug.Log("Sono qui");
        if (pet==null) return;
        pet.ProvaLevelUp();
        Debug.Log("Sono qui");
        //Debug.Log("PuoUppare: "+pet.PuoLevelUp());
    }

}

