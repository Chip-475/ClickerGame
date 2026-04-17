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

    [System.Serializable]
    public class pet
    {
        [Header("Identifier")]
        public string name;
        public Sprite sprite;
        public rarity rarity;

        [Header("Stats")]
        public int lvl;
        public int baseCost;
        public int rank;
        public float moneyMod;
        public float critMod;

        [Header("Post Start")]
        public int finalCost;
        public float finalMoneyMod;
        public int finalCritMod;
    }

    public pet[] petList = new pet[0];
    public static int globalMoneyMod = 1;

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
            globalMoneyMod *= (int)petList[i].finalMoneyMod;
        }
    }

}
