using UnityEngine;

public class petManager : MonoBehaviour
{
    public enum rarity
    {
        common,
        rare,
        epic,
        legendary
    }
    public static float petCritMod;
    public static int petMoneyMod = 1;

    [System.Serializable]
    public class pet
    {
        [Header("Identifier")]
        public int index;
        public string name;
        public Sprite sprite;
        public rarity rarity;

        [Header("Stats")]
        public int lvl;
        public int baseCost;
        public int rank;
        public float moneyMod;

        [Header("Post Start")]
        public int finalCost;
        public float finalMoneyMod;
        public float finalCritMod;
    }

    public pet[] petList = new pet[0];

    public void getCost(pet[] petList)
    {
        int finalCost;

        for (int i = 0; i < petList.Length; i++)
        {
            switch (petList[i].rarity)
            {
                case rarity.common:
                    finalCost = petList[i].lvl * 100;
                    break;
                case rarity.rare:
                    finalCost = petList[i].lvl * 250;
                    break;
                case rarity.epic:
                    finalCost = petList[i].lvl * 500;
                    break;
                case rarity.legendary:
                    finalCost = petList[i].lvl * 1000;
                    break;
                default:
                    finalCost = 0;
                    break;
            }
            petList[i].finalCost = finalCost;
        }
    }
    public void getMoneyMod(pet[] petList)
    {
        for (int i = 0; i <= petList.Length; i++)
        {
            switch (petList[0].rarity)
            {
                case (rarity.common):
                    petList[i].finalMoneyMod = petList[i].moneyMod * petList[i].lvl;
                    break;
                case (rarity.rare):
                    petList[i].finalMoneyMod = petList[i].moneyMod * petList[i].lvl * 1.3f;
                    break;
                case (rarity.epic):
                    petList[i].finalMoneyMod = petList[i].moneyMod * petList[i].lvl * 1.6f;
                    break;
                case (rarity.legendary):
                    petList[i].finalMoneyMod = petList[i].moneyMod * petList[i].lvl * 2;
                    break;
                default:
                    petList[i].finalMoneyMod = 1;
                    break;
            }
        }
        
        for (int i = 0;i <= petList.Length; i++)
        {
            petMoneyMod *= (int)petList[i].finalMoneyMod;
        }
    }
    public void getCritMod(pet[] petList)
    {
        for (int i = 0; i <= petList.Length; i++)
        {
            float x = 0;
            switch (petList[0].rarity)
            {
                case (rarity.common):
                    petList[i].finalCritMod = 2.5f * petList[i].lvl * petList[i].rank;
                    break;
                case (rarity.rare):
                    petList[i].finalCritMod = 1.5f * petList[i].lvl * petList[i].rank;
                    break;
                case (rarity.epic):
                    petList[i].finalCritMod = 2f * petList[i].lvl * petList[i].rank;
                    break;
                case (rarity.legendary):
                    petList[i].finalCritMod = 2.5f * petList[i].rank * (petList[i].lvl/25);
                    break;
                default:
                    petList[i].finalCritMod = 0;
                    break;
            }
            x += petList[i].finalCritMod;
            Mathf.Clamp(x, 0, 25);
            petCritMod = x;
        }
    }

    public pet[] petGetter()
    {
        return petList;
    }

}
