using TMPro;
using UnityEngine;

public class petEquipButton : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private petStats stats;

    private petBox box;
    private PetUI ui;

    private void Start()
    {
        box = GetComponentInParent<petBox>();
        ui = GetComponentInParent<PetUI>();
    }

    private void Update()
    {
        box = GetComponentInParent<petBox>();
        bool canEquip = stats.CanEquip(box.pet);
        box.equipButton.SetActive(canEquip);
        if(box.pet.isEquipped == false&&!canEquip && stats.GetEquippedPetCount() > data.maxEquippedPets)
        {
            box.equipButtonFake.SetActive(true);
        }else if(box.pet.isEquipped==true)
        {
            box.unequipButton.SetActive(true);
        }
    }

    public void ToggleEquip()
    {
        foreach (var pet in data.pets)
        {
            if (pet.petId != box.pet.petId)
            {
                continue;
            }
            if (!pet.isEquipped && !stats.CanEquip(pet))
            {
                return;
            }
            pet.isEquipped = !pet.isEquipped;
            stats.getGlobalBonus();
            PetSave.Save(new data());
            ui.buildUI();
            return;
        }
    }
}
