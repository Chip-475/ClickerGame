using UnityEngine;
using UnityEngine.UI;

public class sortManager : MonoBehaviour
{
    public Button rarityButton;
    public Button rankButton;
    public Button levelButton;
    public PetUI ui;
    public Sprite toggleSort1;
    public Sprite toggleSort2;
    public bool sortOrder;
    public Image toggleSprite;
    public enum sorting
    {
        rarity,
        rank,
        level
    }
    static public sorting type;
    public void setRaritySort()
    {
            type = sorting.rarity;
            rarityButton.interactable = false;
            rankButton.interactable = true;
            levelButton.interactable = true;
        ui.buildUI();
    }
    public void setRankSort()
    {
        type = sorting.rank;
        rankButton.interactable = false;
        levelButton.interactable = true;
        rarityButton.interactable= true;
        ui.buildUI();
    }
    public void setLevelSort()
    {
        type = sorting.level;
        levelButton.interactable = false;
        rankButton.interactable = true;
        rarityButton.interactable= true;
        ui.buildUI();
    }
    public void toggleSortOrder()
    {
        sortOrder = !sortOrder;
        if( sortOrder )
        {
            toggleSprite.sprite = toggleSort1;
        }
        else
        {
            toggleSprite.sprite = toggleSort2;
        }
        ui.buildUI();
    }
    void Start()
    {
        type= sorting.rarity;
        toggleSprite.sprite = toggleSort1;
        sortOrder = true;
    }
}
