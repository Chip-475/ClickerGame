using UnityEngine; 
public enum rarita
{
    common,
    rare,
    leggend
}
public abstract class SuperPets : MonoBehaviour
{
    [SerializeField] private GameObject buttonLevelUP;
    protected int level; // da 1 a 10
    protected int rank;  // da 1-3 
    [SerializeField] protected rarita rar; // -1 common    0 rari   1 leggendari
    protected float stamina=100f; // da 0 a 100;
    protected float staminaRate=10f;


    public int getLevel() { return level; }
    public int getRank() { return rank; }
    //public rarita getRarity() { return rarity; }
    public float getStamina() { return stamina; }

    // abstract protected void livella(); //serve il button

    protected void rigeneraStam()
    {
        stamina+=staminaRate * Time.deltaTime;
        stamina+=Mathf.Clamp(stamina, 0f, 100f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /* void Start()
    {
        
    }*/
    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
