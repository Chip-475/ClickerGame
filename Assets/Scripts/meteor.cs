using System.Buffers.Text;
using System.Collections;
using TMPro;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public GameObject met;
    public TMP_Text metHp;
    public static int hpMeteor;
    public static int hpMaxMeteor;
    bool x = true;
    
    private void meteorLvl()
    {
        data.meteorCrushed++;
        data.meteorlvl = (int)(15 * (1 + data.meteorCrushed/3 * 0.05f) * Mathf.Pow(1.05f, data.meteorCrushed/3));
    }
    IEnumerator Meteor()
    {
        data.money += hpMaxMeteor * petManager.petMoneyMod;
        if (goldMeteorPerk.isActive)
        {
            data.money += hpMaxMeteor * petManager.petMoneyMod * 4;
            goldMeteorPerk.isActive=false;
        }
        met.SetActive(false);
        meteorLvl();
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
        metHp.text =hpMeteor +"/"+ hpMaxMeteor;
        if(x && hpMeteor <= 0)
        {
            StartCoroutine(Meteor());
            x = false;
        }
    }
}
