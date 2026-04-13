using System;
using UnityEngine;

public class SuperUovo : MonoBehaviour
{
    public string nomeUovo;
    public int[] costoApertura = new int[5];

    [Serializable]
    public struct Pet
    {
        public GameObject pet;
        [Range(0f, 100f)] public float percentuale;
    }

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

    void Update()
    {
        aggiornaStatoUovo(0, uovo1, uovo1_fake);
        aggiornaStatoUovo(1, uovo2, uovo2_fake);
        aggiornaStatoUovo(2, uovo3, uovo3_fake);
        aggiornaStatoUovo(3, uovo4, uovo4_fake);
        aggiornaStatoUovo(4, uovo5, uovo5_fake);
    }

    private void aggiornaStatoUovo(int indice, GameObject uovoVero, GameObject uovoFinto)
    {
        if (costoApertura == null) return;
        if (indice < 0 || indice >= costoApertura.Length) return;

        bool puoComprare = data.money >= costoApertura[indice];

        if (uovoVero != null) uovoVero.SetActive(puoComprare);
        if (uovoFinto != null) uovoFinto.SetActive(!puoComprare);
    }

    public GameObject ApriUovo1()
    {
        return ApriUovo(0, poolUovo1);
    }

    public GameObject ApriUovo2()
    {
        return ApriUovo(1, poolUovo2);
    }

    public GameObject ApriUovo3()
    {
        return ApriUovo(2, poolUovo3);
    }

    public GameObject ApriUovo4()
    {
        return ApriUovo(3, poolUovo4);
    }

    public GameObject ApriUovo5()
    {
        return ApriUovo(4, poolUovo5);
    }

    private GameObject ApriUovo(int indiceCosto, Pet[] poolScelto)
    {
        if (!puoAprire(indiceCosto, poolScelto)) return null;

        data.money -= costoApertura[indiceCosto];

        GameObject petEstratto = EstraiPet(poolScelto);

        if (petEstratto == null) return null;

        PreparaPassaggioInventario(petEstratto);

        return petEstratto;
    }

    private bool puoAprire(int indiceCosto, Pet[] poolScelto)
    {
        if (costoApertura == null) return false;
        if (indiceCosto < 0 || indiceCosto >= costoApertura.Length) return false;
        if (data.money < costoApertura[indiceCosto]) return false;
        if (poolScelto == null || poolScelto.Length == 0) return false;
        if (SommaPercentuali(poolScelto) <= 0f) return false;

        return true;
    }

    private GameObject EstraiPet(Pet[] poolScelto)
    {
        float totale = SommaPercentuali(poolScelto);
        float roll = UnityEngine.Random.Range(0f, totale);
        float cumulativa = 0f;

        for (int i = 0; i < poolScelto.Length; i++)
        {
            if (poolScelto[i].percentuale <= 0f) continue;

            cumulativa += poolScelto[i].percentuale;

            if (roll <= cumulativa)
            {
                return poolScelto[i].pet;
            }
        }

        return poolScelto[poolScelto.Length - 1].pet;
    }

    private float SommaPercentuali(Pet[] poolScelto)
    {
        float totale = 0f;

        for (int i = 0; i < poolScelto.Length; i++)
        {
            if (poolScelto[i].percentuale > 0f)
            {
                totale += poolScelto[i].percentuale;
            }
        }

        return totale;
    }

    protected virtual void PreparaPassaggioInventario(GameObject petEstratto)
    {
        if (petEstratto == null) return;

        // predisposizione futura per il passaggio all'inventario
        // esempio futuro:
        // inventario.AggiungiPet(petEstratto);
    }
}
