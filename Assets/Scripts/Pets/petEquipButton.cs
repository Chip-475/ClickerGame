using TMPro;
using UnityEngine;

public class petEquipButton : MonoBehaviour
{
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
        if(box.pet.isEquipped == false&&!canEquip && stats.GetEquippedPetCount() >= data.maxEquippedPets)
        {
            box.equipButton.SetActive(false);
            box.equipButtonFake.SetActive(true);
            box.unequipButton.SetActive(false);
        }
        else if(box.pet.isEquipped==true)
        {
            box.equipButton.SetActive(false);
            box.unequipButton.SetActive(true);
            box.equipButtonFake.SetActive(false);
        }
        else
        {
            box.equipButton.SetActive(true);
            box.equipButtonFake.SetActive(false);
            box.unequipButton.SetActive(false);
        }
    }
    public void equip()
    {
        foreach (var pet in data.pets)
        {
            if (pet.petId == box.pet.petId)
            {
                pet.isEquipped = true;
                stats.getGlobalBonus();
                Debug.Log(data.globalCritMod + " " + data.globalMoneyMod);
                PetSave.Save(new data());
                ui.buildUI();
                return;
            }
        }
    }
    public void unequip()
    {
        foreach (var pet in data.pets)
        {
            if (pet.petId == box.pet.petId)
            {
                pet.isEquipped = false;
                stats.getGlobalBonus();
                Debug.Log(data.globalCritMod + " " + data.globalMoneyMod);
                PetSave.Save(new data());
                ui.buildUI();
                return;
            }
        }
    }
}
