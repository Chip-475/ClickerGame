using UnityEngine;
using TMPro;
public class clicker : MonoBehaviour
{
    public static int clickStr = 1;
    public GameObject testo;
    public Transform bottone;


    public void click()
    {
        data.money += clickStr;
    }
    public void crit()
    {
        int r = UnityEngine.Random.Range(0, 10);
        if (r <= data.critUPlvl)
        {
            data.money += clickStr * 5; 
            testo.SetActive(true);
            float spstX, spstY;
            do
            {
                spstX = Random.Range(-100f, 100f);  
                spstY = Random.Range(-100f, 100f);
            } while (spstX > -30f && spstX < 30 && spstY > -30f && spstY < 30f);  //accusi non si mette sopra il bottone e ritenta
            testo.transform.position = bottone.position + new Vector3(spstX, spstY, 0);
            Invoke("disattiva",1f); //per aspettare
        }
    }

    public void disattiva()
    {
        testo.SetActive(false);
    }
}
