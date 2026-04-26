using TMPro;
using UnityEngine;

public class petRankUpButton : MonoBehaviour
{
    [SerializeField] private petStats stats;
    public petBox box;
    private PetUI ui;
    public PetInstance pet2;
    private void Start()
    {
        ui = GetComponentInParent<PetUI>();
        box = GetComponentInParent<petBox>();
    }
    private bool rankUpCheck(PetInstance pet)
    {
        if (pet.Petlvl != stats.getMaxlvl(pet))
        {
            return false;
        }
        foreach (var otherPet in data.pets)
        {
            if (otherPet.petId == pet.petId)
            {
                continue;
            }
            if (otherPet.petName != pet.petName)
            {
                continue;
            }
            if (otherPet.Petlvl != stats.getMaxlvl(otherPet))
            {
                continue;
            }
            return true;
        }
        return false;
    }
    private void Update()
    {
        box = GetComponentInParent<petBox>();
        if (rankUpCheck(box.pet))
        {
            box.RankUPButton.SetActive(true);
            box.RankUPButtonFake.SetActive(false);
        }
        else
        {
            box.RankUPButton.SetActive(false);
            box.RankUPButtonFake.SetActive(true);
        }
    }
    public void rankUP()
    {
        string id = box.pet.petId;
        for (int index = 0; index < data.pets.Count; index++)
        {
            if (id == data.pets[index].petId)
            {
                if (rankUpCheck(data.pets[index]))
                {
                    foreach (var otherPet in data.pets)
                    {
                        if (otherPet.petId == box.pet.petId)
                        {
                            continue;
                        }
                        if (otherPet.petName != box.pet.petName)
                        {
                            continue;
                        }
                        if (otherPet.Petlvl != stats.getMaxlvl(otherPet))
                        {
                            continue;
                        }
                        pet2 = otherPet;
                        break;
                    }
                    data.pets[index].rank++;
                    data.pets[index].Petlvl = 1;
                    data.pets.Remove(pet2);
                    stats.getGlobalBonus();
                    PetSave.Save(new data());
                    ui.buildUI();
                    break;
                }

            }
        }
    }
}
