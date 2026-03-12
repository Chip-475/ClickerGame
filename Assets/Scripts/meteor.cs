using System.Collections;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject met;
    public static int hp;
    public static int hpMax;
    bool active;
    IEnumerator createMeteor()
    {
        active = true;
        data.money += hpMax;
        hpMax = Random.Range(data.meteorlvl * 3, data.meteorlvl * 5);
        hp = hpMax;
        met.SetActive(false);
        yield return new WaitForSeconds(2f);
        met.SetActive(true);
    }

    public void Update()
    {
        if(hp<=0) active = false;
        if (!active)
        {
            StartCoroutine(createMeteor());
        }
    }
}
