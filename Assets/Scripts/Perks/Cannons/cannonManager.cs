using UnityEngine;
using System.Collections;

public class cannonManager : MonoBehaviour
{
    //WIP NON MODIFICARE DIO CANE BASTARDO
    public bool shoot1, shoot2;
    public GameObject cannon_1, cannon_2;
    public int shootCost1, shootCost2;
    public float fireTime1, fireTime2;
    public GameObject[] perk = new GameObject[0];
    private bool shooting1, shooting2;
    
    IEnumerator cannon1()
    {
        shooting1 = true;
        int x = Random.Range(-500, 500);
        int y = 50;
        float step;
        int r = Random.Range(0, 2);
        Vector3 point = new Vector2(x, y);
        while(cannon_1.transform.rotation != Quaternion.FromToRotation(cannon_1.transform.position, cannon_1.transform.position + point))
        {
            step = Time.deltaTime * 15;
            cannon_1.transform.rotation =
            Quaternion.RotateTowards
            (
                cannon_1.transform.rotation,
                Quaternion.FromToRotation(cannon_1.transform.position, cannon_1.transform.position + point),
                step
            );
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(fireTime1);
        //Instantiate(perk[r], cannon_1.transform.position, Quaternion.identity);
        data.fuel1 -= 10;
        shooting1 = false;
        step = 0;
    } 
    IEnumerator cannon2()
    {
        shooting2 = true;
        int x = Random.Range(-500, 500);
        int y = 50;
        float step;
        int r = Random.Range(0, 2);
        Vector3 point = new Vector2(x, y);
        while (cannon_2.transform.rotation != Quaternion.FromToRotation(cannon_2.transform.position, cannon_2.transform.position + point))
        {
            step = Time.deltaTime * 15;
            cannon_1.transform.rotation =
            Quaternion.RotateTowards
            (
                cannon_2.transform.rotation,
                Quaternion.FromToRotation(cannon_2.transform.position, cannon_2.transform.position + point),
                step
            );
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(fireTime2);
        //Instantiate(perk[r], cannon_2.transform.position, Quaternion.identity);
        data.fuel2 -= 10;
        shooting2 = false;
        step = 0;
    }
    void Update()
    {
        if (shoot1 && data.fuel1 >= shootCost1)
        {
            if (!shooting1)
            {
                StartCoroutine(cannon1());
                Debug.Log(gameObject.name);
            }
        }
        if (shoot2 && data.fuel2 >= shootCost2)
        {
            if (!shooting2)
            {
                StartCoroutine(cannon2());
            }
        }
    }
}
