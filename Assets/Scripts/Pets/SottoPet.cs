using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UI;
public class SottoPet : SuperPets
{
    private ButtonPet b1;
    [SerializeField] private GameObject zona;
    [SerializeField] private float muovi = 3f;
    [SerializeField] private float tempAttesa = 2f;
    private Rigidbody2D rb;
    private float timer = 0f;
    private Vector2 ultimaPos;
    bool muove;


    void Start()
    {
        Debug.Log("Rarita " + rar);
    }

    void Awake()
    {
        b1 = GetComponentInChildren<ButtonPet>();
        rb = GetComponent<Rigidbody2D>();
        ultimaPos = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina > 0) muove = true;
        if (muove)
        {
            timer += Time.deltaTime;
            if (timer >= tempAttesa)
            {
                muove = false;
                riposa();
            }
            if (Vector2.Distance(rb.position, zona.transform.position) < 0.3f) RigeneraStam();
        }
        else
        {
            timer = 0f;
        }
        ultimaPos = rb.position;
    }

    private void riposa()
    {
        Vector2 direzione = (zona.transform.position - transform.position).normalized;
        rb.linearVelocity = direzione * muovi;
        stamina = 100;
        if (stamina >= 100) muove = true;
    }
}