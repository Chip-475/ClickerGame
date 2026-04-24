using TMPro;
using UnityEngine;

public class petLevelUPButton : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private petStats stats;
    public petBox box;
    public int cost;

    private void Update()
    {
        petBox box = GetComponentInParent<petBox>();
        cost=stats.UpgradeCost(box.pet);
        costText.text=cost.ToString();
        if (cost < data.money)
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
                break;
            }
        }
    }
}

