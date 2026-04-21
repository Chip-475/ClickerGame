using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UI;
public class SottoPet : SuperPets
{
    private ButtonPet b1;
    private RectTransform rect;
    [SerializeField] private GameObject zona;
    [SerializeField] private float muovi = 3f;
    [SerializeField] private float tempAttesa = 2f;
    private Rigidbody2D rb;
    private float timer=0f;
    private Vector2 direzione;
    bool muove;

    void Start()
    {
        Debug.Log("Rarita " + rar);
    }

    void Awake()
    {
        b1=GetComponentInChildren<ButtonPet>();
        //rb=GetComponent<Rigidbody2D>();
        rect=GetComponentInChildren<RectTransform>();
        direzione=Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {

        if(stamina>0)
        {
            rect.anchoredPosition += direzione * muovi * Time.deltaTime;
            stamina -= Time.deltaTime * consumaStamina;
            controllaBordi();
        }
        else
        {
            rect.anchoredPosition=Vector2.zero;
            riposa();
        }

        /*
        if(stamina>0) muove = true;
        if(muove)
        {
            timer += Time.deltaTime;
            if(timer >=tempAttesa)
            {
                muove=false;
                riposa();
            }
            if(Vector2.Distance(rb.position, zona.transform.position) < 0.3f) RigeneraStam();
        }
        else
        {\
            timer = 0f;
        }
        ultimaPos = rb.position;*/
    }
   
    private void riposa()
    {
        rect.anchoredPosition=Vector2.zero;
        stamina += Time.deltaTime * 20f;
        if(stamina>=100)
        {
            stamina = 100;
            direzione=Random.insideUnitCircle.normalized;
        }
        /*
        Vector2 direzione = (zona.transform.position - transform.position).normalized;
        rb.linearVelocity = direzione * muovi;
        stamina = 100;
        if (stamina >= 100) muove = true;*/
    }

    private void controllaBordi()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(rect.position);
        if (pos.x < 0f || pos.x > 1f)direzione.x *= -1;
        if (pos.y < 0f || pos.y > 1f)direzione.y *= -1;
        direzione.Normalize();
    }
}