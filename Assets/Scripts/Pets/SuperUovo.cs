using System;
using System.ComponentModel.DataAnnotations;
using UnityEngine;

public class SuperUovo : Monobehaviour
{
    public string nomeUovo;
    public int[] costoApertura = new int[0];

    public struct Pet
    {
        public gameObject pet;
        [Range(0f, 100f)] public float percentuale;
    }

    public Pet[] pool = new Pet[0];

      public Pet[] poolUovo1 = new Pet[0];
    public Pet[] poolUovo2 = new Pet[0];
    public Pet[] poolUovo3 = new Pet[0];
    public Pet[] poolUovo4 = new Pet[0];
    public Pet[] poolUovo5 = new Pet[0];

    public GameObject uovo1;
    public GameObject uovo1_fake;
    public GameObject uovo2;
    public GameObject uovo2_fake;
    public GameObject uovo3;
    public GameObject uovo3_fake;
    public GameObject uovo4;
    public GameObject uovo4_fake;
    public GameObject uovo5;
    public GameObject uovo5_fake;
    void update()
    {
        if (data.money < costoApertura[0])
        {
            uovo1.SetActive(false);
            uovo1_fake.SetActive(true);
        }
        else
        {
            uovo1.SetActive(true);
            uovo1_fake.SetActive(false);
        }
        if (data.money < costoApertura[1])
        {
            uovo2.SetActive(false);
            uovo2_fake.SetActive(true);
        }
        else
        {
            uovo2.SetActive(true);
            uovo2_fake.SetActive(false);
        }
        if (data.money < costoApertura[2])
        {
            uovo3.SetActive(false);
            uovo3_fake.SetActive(true);
        }
        else
        {
            uovo3.SetActive(true);
            uovo3_fake.SetActive(false);

        }
        if (data.money < costoApertura[3])
        {
            uovo4.SetActive(false);
            uovo4_fake.SetActive(true);
        }
        else
        {
            uovo4.SetActive(true);
            uovo4_fake.SetActive(false);
        }
        if (data.money < costoApertura[4])
        {
            uovo5.SetActive(false);
            uovo5_fake.SetActive(true);
        }
        else
        {
            uovo5.SetActive(true);
            uovo5_fake.SetActive(false);
        }
    }


 public GameObject ApriUovo1()
    {
        return ApriUovo(0, poolUovo1);
        float randomValue = UnityEngine.Random.Range(0f, 100f);

        

    }


}
