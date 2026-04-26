using System;
using TMPro;
using UnityEngine;

public class petLevelUPButton : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private petStats stats;
    public petBox box;
    public int cost;
    public int lvl;
    public int maxLvl;
    private PetUI ui;
    private void Start()
    {
        ui=GetComponentInParent<PetUI>();
    }
    private void Update()
    {
        box = GetComponentInParent<petBox>();
        cost=stats.UpgradeCost(box.pet);
        lvl=stats.getLvl(box.pet);
        maxLvl=stats.getMaxlvl(box.pet);
        costText.text=cost.ToString();
        if (cost < data.money&&lvl<maxLvl)
        {
            box.lvlUPButton.SetActive(true);
            box.lvlUPButtonFake.SetActive(false);
        }
        else
        {
            box.lvlUPButton.SetActive(false);
            box.lvlUPButtonFake.SetActive(true);
        }
    }
    public void lvlUP()
    {
        string id = box.pet.petId;
        for (int index = 0; index < data.pets.Count; index++)
        {
            if (id == data.pets[index].petId)
            {
                data.pets[index].Petlvl++;
                data.money -= cost;
                data.pets[index].currentMoneyMod = stats.getMoneyBonus(data.pets[index]);
                data.pets[index].currentCritMod = stats.getCritBonus(data.pets[index]);
                stats.getGlobalBonus();
                PetSave.Save(new data());
                ui.buildUI();
                break;
            }
        }
    }
}

