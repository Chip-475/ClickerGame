using UnityEngine;

public class SuperPets : MonoBehaviour
{
    public string nomeSpecie;
    public int rarita;
    public int livello = 1;
    public int rank = 1;

    public void TentaFusione(SuperPets pet1)
    {
        if (pet1 == null) return;
        if (this.nomeSpecie != pet1.nomeSpecie) return;
        if (this.rarita != pet1.rarita) return;
        if (this.livello < 10 || pet1.livello < 10) return;
        if (this.rank != pet1.rank || this.rank >= 3) return;

        rank++;
        livello = 1;
        Destroy(pet1.gameObject);
    }
}

public class GestorePet : MonoBehaviour
{
    public SuperPets pet1;
    public SuperPets pet2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (pet1 != null && pet2 != null)
            {
                pet1.TentaFusione(pet2);
            }
        }
    }
}