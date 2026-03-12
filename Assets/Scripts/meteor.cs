using System.Collections;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject met;
    public static int hpMeteor;
    public static int hpMaxMeteor;
    bool x = true;
    IEnumerator Meteor()
    {
        data.money += hpMaxMeteor;
        met.SetActive(false);
        hpMaxMeteor = Random.Range(data.meteorlvl * 3, data.meteorlvl * 5);
        yield return new WaitForSeconds(2);
        met.SetActive(true);
        hpMeteor = hpMaxMeteor;
        x = true;
    }

    private void Start()
    {
        hpMaxMeteor = Random.Range(data.meteorlvl * 3, data.meteorlvl * 5);
        hpMeteor = hpMaxMeteor;
    }

    public void Update()
    {
        
        if(x && hpMeteor <= 0)
        {
            StartCoroutine(Meteor());
            x = false;
        }
    }
}
