using UnityEngine;
using TMPro;
public class dropdownmanager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject ClickUpgrade;
    public GameObject CannonUpgrade;
    public GameObject Pets;
    int index;
    public void Update()
    {
        index = dropdown.value;
        switch(index)
        {
            case 0:
                ClickUpgrade.SetActive(true);
                CannonUpgrade.SetActive(false);
                Pets.SetActive(false);
                break;
            case 1:
                ClickUpgrade.SetActive(false);
                CannonUpgrade.SetActive(true);
                Pets.SetActive(false);
                break;
            case 2:
                ClickUpgrade.SetActive(false);
                CannonUpgrade.SetActive(false);
                Pets.SetActive(true);
                break;
        }
    }

}
