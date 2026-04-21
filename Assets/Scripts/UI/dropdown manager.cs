using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dropdownmanager : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject ClickUpgrade;
    public GameObject CannonUpgrade;
    public GameObject Pets;
    public Sprite ClickImage;
    public Sprite CannonImage;
    public Sprite PetsImage;
    public Image ClickImage1;
    public Image CannonImage1;
    public Image PetsImage1;
    public int index;
    public void Start()
    {
        dropdown.options[0].image = ClickImage;
        dropdown.options[1].image = CannonImage;
        dropdown.options[2].image = PetsImage;
    }
    public void Update()
    {
        index = dropdown.value;
        switch(index)
        {
            case 0:
                ClickUpgrade.SetActive(true);
                CannonUpgrade.SetActive(false);
                Pets.SetActive(false);
                dropdown.captionImage = ClickImage1;
                break;
            case 1:
                ClickUpgrade.SetActive(false);
                CannonUpgrade.SetActive(true);
                Pets.SetActive(false);
                dropdown.captionImage = CannonImage1;
                break;
            case 2:
                ClickUpgrade.SetActive(false);
                CannonUpgrade.SetActive(false);
                Pets.SetActive(true);
                dropdown.captionImage = PetsImage1;
                break;
        }
    }

}
