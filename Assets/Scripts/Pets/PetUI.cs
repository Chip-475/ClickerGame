using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetUI : MonoBehaviour
{
    public GameObject petPrefab;
    public GameObject parent;


    private int oldPet;
    private void Start()
    {
        buildUI();
    }
    private void Update()
    {
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
            petInst.GetComponent<petBox>().pet = p;
            petInst.GetComponent<petBox>().petName.text = p.petName;
            petInst.GetComponent<petBox>().petLevel.text = "" + p.Petlvl;
            petInst.GetComponent<petBox>().petRank.text = "" + p.rank;
        }
    }
}