using UnityEngine;
public enum rarita
{
    common,
    rare,
    leggend
}
public class SuperPets : MonoBehaviour
{
    protected int stamina;
    protected string nomeSpecie;
    [SerializeField] protected rarita rar;
    protected int livello = 1;
    protected int rank = 1;
    [SerializeField] protected SuperPets pet2;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(pet2 != null)
            {
                this.TentaFusione();
            }
        }
    }

    public void TentaFusione()
    {
        if (this.nomeSpecie != pet2.nomeSpecie) return;
        if (this.rar != pet2.rar) return;
        if (this.livello < 10 || pet2.livello < 10) return;
        if (this.rank != pet2.rank || this.rank >= 3) return;

        rank++;
        livello = 1;
        Destroy(pet2.gameObject);
    }

    public void rigeneraStam()
    {
        stamina++;
        if (stamina > 100) stamina = 100;
    }


}