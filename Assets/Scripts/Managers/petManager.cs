using UnityEngine;

public class petManager : MonoBehaviour
{   
    /*public void getCost(petData[] petList)
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
            petList[i].finalUPcost = finalCost;
        }
    }
    public void getMoneyMod(petData[] petList)
    {
        for (int i = 0; i <= petList.Length; i++)
        {
            switch (petList[0].rarity)
            {
                case (rarity.common):
                    petList[i].finalMoneyMod = petList[i].baseMoneyMod * petList[i].lvl;
                    break;
                case (rarity.rare):
                    petList[i].finalMoneyMod = petList[i].baseMoneyMod * petList[i].lvl * 1.3f;
                    break;
                case (rarity.epic):
                    petList[i].finalMoneyMod = petList[i].baseMoneyMod * petList[i].lvl * 1.6f;
                    break;
                case (rarity.legendary):
                    petList[i].finalMoneyMod = petList[i].baseMoneyMod * petList[i].lvl * 2;
                    break;
                default:
                    petList[i].finalMoneyMod = 1;
                    break;
            }
        }
        
        for (int i = 0;i <= petList.Length; i++)
        {
            data.globalMoneyMod *= (int)petList[i].finalMoneyMod;
        }
    }
    public void getCritMod(petData[] petList)
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
            data.globalCritMod = x;
        }
    }*/
}
