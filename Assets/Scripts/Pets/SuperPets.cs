using UnityEngine;
public enum Rarita
{
    Common,     
    Rare,
    Leggend
}
public class SuperPets : MonoBehaviour
{
    [SerializeField] protected string nomeSpecie;
    [SerializeField] protected Rarita rar;
    [SerializeField] protected int livello = 1;
    [SerializeField] protected int rank = 1;
    [SerializeField] SuperPets pet2;
    [SerializeField] protected int livelloMax = 10;
    [SerializeField] protected int consumaStamina=2;


    [Header("Statistiche Pet")]
    [SerializeField] protected float potenzaBase = 10f;
    [SerializeField] protected float potenzaAttuale = 10f;
    [SerializeField] protected float stamina = 100f;


    [Header("costo level up")]
    [SerializeField] protected int costoBaseLevelUP = 50;


    void Start()
    {
        AggiornaPotenza();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (pet2 != null)
            {
                TentaFusione();
            }
        }
    }


    public void TentaFusione()
    {
        if (nomeSpecie != pet2.nomeSpecie) return;
        if (rar != pet2.rar) return;
        if (livello < 10 || pet2.livello < 10) return;
        if (rank != pet2.rank || rank >= 3) return;

        rank++;
        livello = 1;
        AggiornaPotenza();
        Destroy(pet2.gameObject);
    }

    public void RigeneraStam()
    {
        stamina++;
        if (stamina > 100) stamina = 100;
    }

    public int GetLivello()
    {
        return livello;
    }

    public int GetRank()
    {
        return rank;
    }

    public Rarita GetRarita()
    {
        return rar;
    }

    public float GetPotenza()
    {
        return potenzaAttuale;
    }

    public int GetCostoLevelUp()
    {
        float moltiplicatoreRarita = 1f;

        if (rar==Rarita.Rare)
        {
            moltiplicatoreRarita = 2f;
        }
        else if (rar==Rarita.Leggend)
        {
            moltiplicatoreRarita = 4f;
        }
        float scalaLivello = 1f + ((livello - 1) * 0.75f);
        float scalaRank = 1f + ((rank - 1) * 0.5f);

        float costoFinale = costoBaseLevelUP * moltiplicatoreRarita * scalaLivello * scalaRank;
        return Mathf.RoundToInt(costoFinale);
    }

    public bool PuoLevelUp()
    {
        if (livello >= livelloMax) return false;
        if (data.money < GetCostoLevelUp()) return false;
        return true;
    }

    public bool ProvaLevelUp()
    {
        if(!PuoLevelUp()) return false;

        int costo = GetCostoLevelUp();

        data.money -= costo;
        livello++;
        AggiornaPotenza();

        return true;
    }

    protected void AggiornaPotenza()
    {
        float moltiplicatoreRarita = 1f;

        if (rar == Rarita.Rare)
        {
            moltiplicatoreRarita = 1.5f;
        }
        else if (rar == Rarita.Leggend)
        {
            moltiplicatoreRarita = 2.2f;
        }

        float bonusLivello = 1f + ((livello - 1) * 0.35f);
        float bonusRank = 1f + ((rank - 1) * 0.60f);
        potenzaAttuale = potenzaBase * moltiplicatoreRarita * bonusLivello * bonusRank;
    }

}