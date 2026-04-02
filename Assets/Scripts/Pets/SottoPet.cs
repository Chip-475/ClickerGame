using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UI;

public class SottoPet : SuperPets
{
    [SerializeField] private Button b1;
    [SerializeField] private GameObject zona;
    [SerializeField] private float muovi=3f;
    [SerializeField] private float tempAttesa=2f;
    private Rigidbody2D rb;
    private float timer=0f;
    private Vector2 ultimaPos;
    bool muove;
    private float minX, maxX, minY, maxY;
    //per controllare i bordi mettere i muri, dei gameObject
    void Start()
    {
        float height=Screen.height/2;
        float width=Screen.width/2;
        b1.onClick.AddListener(OnButtonClicked);
        Debug.Log("Rarita " + rar);
    }

    void Awake()
    {
        //b1 = GetComponentInChildren<ButtonPet>();
        rb = GetComponent<Rigidbody2D>();
        ultimaPos = rb.transform.position;
    }

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
            if (Vector2.Distance(rb.position, zona.transform.position) < 0.3f) rigeneraStam();
        }
        else
        {
            timer = 0f;
        }
        ultimaPos = rb.position;
        limitaPosizione();
        //verificaBottone();
    }
    /*
    private void verificaBottone()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click rilevato");
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hai cliccato: " + hit.collider.gameObject.name);
                hit.collider.GetComponent<ButtonPet>()?.levelUp();
            }
            else Debug.Log("nessun collider");
        }
    }*/
    private void limitaPosizione()
    {
        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxY);
        pos.y = Mathf.Clamp(pos.y, minX, maxY);
        rb.position = pos;
    }
    void OnButtonClicked()
    {
        Debug.Log("SIIII");
    }

    private void riposa()
    {
        Vector2 direzione = (zona.transform.position - transform.position).normalized;
        rb.linearVelocity = direzione * muovi;
        stamina = 100;
        //if (stamina >= 100) muove = true;
    }
}