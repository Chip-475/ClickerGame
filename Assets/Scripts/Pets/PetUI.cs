using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class PetUI : MonoBehaviour
{
    public GameObject petPrefab;
    public GameObject parent;
    public TMP_Text equippedText;
    [SerializeField] private petStats stats;

    private int oldPet;
    private void Start()
    {
        buildUI();
    }
    private void Update()
    {
        equippedText.text = stats.GetEquippedPetCount() + "/" + data.maxEquippedPets;
        if (data.pets.Count != oldPet)
        {
            oldPet = data.pets.Count;
            buildUI();

        }
    }
    public void buildUI()
    {
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.transform.GetChild(i).gameObject);
        }
        foreach (var p in data.pets)
        {
            var petInst = Instantiate(petPrefab, parent.transform);
            var box = petInst.GetComponent<petBox>();
            box.pet = p;
            box.petName.text = p.petName;
            box.petLevel.text = p.Petlvl.ToString() + "/" + p.rank * 10;
            box.petRank.text = "" + p.rank;
        }
        oldPet = data.pets.Count;
        stats.getGlobalBonus();
    }
}
