using UnityEngine;

public class SottoPet : SuperPets
{

    [SerializeField] private Transform zona;
    [SerializeField] private float muovi=3f;
    [SerializeField] private float tempAttesa=2f;
    private Rigidbody2D rb;
    private float timer = 0f;
    private Vector2 ultimaPos;
    bool muove;

    void awake()
    {
        //butttonLevelUP=GetComponent<>
        rb=GetComponent<Rigidbody2D>();
        ultimaPos=rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(stamina>0)muove=true;
        
        if(muove)
        {
            timer+=Time.deltaTime;
            if (timer >= tempAttesa)
            {
                muove = false;
                riposa();
            }
            if (Vector2.Distance(rb.position, zona.position)<0.3f) rigeneraStam();
        }
        else
        {
            timer=0f;
        }
        ultimaPos=rb.position;
    }

    private void riposa()
    {
        Vector2 direzione=(zona.position-transform.position).normalized;
        rb.linearVelocity = direzione * muovi;
        stamina = 100;
        if (stamina >= 100) muove = true;
    }
}
