using TMPro;
using UnityEngine;

public class sellPet : MonoBehaviour
{
    [SerializeField] private TMP_Text sellText;
    [SerializeField] private petStats stats;
    public petBox box;
    public int sell;
    private PetUI ui;
    private void Start()
    {
        ui = GetComponentInParent<PetUI>();
    }
    private void Update()
    {
        box = GetComponentInParent<petBox>();
        sell = stats.getSellValue(box.pet);
        sellText.text = "sell:" + sell;
    }
    public void Sell()
    {
        for (int i = 0; i < data.pets.Count; i++)
        {
            if (data.pets[i].petId == box.pet.petId)
            {
                data.money += sell;
                data.pets.RemoveAt(i);
                break;
            }
        }
    }
}
