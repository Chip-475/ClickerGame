using UnityEngine;
using System.Collections;
using Unity.Mathematics;

//fuel  a ogni soparo massimi e fire rate 
public class cannonManager : MonoBehaviour
{
    public bool shoot1, shoot2;
    public GameObject cannon_1, cannon_2;
    public int shootCost1, shootCost2;

    [Header("fire rate")]
    public float baseFireTime1 = 1f;
    public float baseFireTime2 = 1f;
    public float fireRateReductionPerLevel = 0.05f;
    private float minFireTime = 0.1f;

    [Header("debot")]
    public int baseMaxFuel1 = 100;
    public int baseMaxFuel2 = 100;
    public int depotBonusPerLevel = 25;

    public GameObject[] perk = new GameObject[0];
    private bool shooting1, shooting2;
    float GetCurrentFireTime(float baseFireTime)
    {
        float currentValue = baseFireTime - (data.cannonFireRatelvl * fireRateReductionPerLevel);
        return Mathf.Max(minFireTime, currentValue);
    }

    int GetCurrentMaxFuel(int baseMaxFuel)
    {
        return baseMaxFuel + (data.cannonDepotlvl * depotBonusPerLevel);
    }

    public int getmaxFuel1()
    {
        return GetCurrentMaxFuel(baseMaxFuel1);
    }

    public int getmaxFuel2()
    {
        return GetCurrentMaxFuel(baseMaxFuel2);
    }

    IEnumerator cannon1()
    {
        shooting1 = true;
        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        float step;
        int r = UnityEngine.Random.Range(0, 2);
        Vector3 point = new Vector2(x, y);

        while (cannon_1.transform.rotation != Quaternion.FromToRotation(cannon_1.transform.position, cannon_1.transform.position + point))
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

        yield return new WaitForSeconds(GetCurrentFireTime(baseFireTime1));
        //Instantiate(perk[r], cannon_1.transform.position, Quaternion.identity);
        data.fuel1 -= shootCost1;
        step = 0;
        shooting1 = false;
    }
    IEnumerator cannon2()
    {
        shooting2 = true;
        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        float step;
        int r = UnityEngine.Random.Range(0, 2);
        Vector3 point = new Vector2(x, y);

        while (cannon_2.transform.rotation != Quaternion.FromToRotation(cannon_2.transform.position, cannon_2.transform.position + point))
        {
            step = Time.deltaTime * 15;
            cannon_2.transform.rotation =
            Quaternion.RotateTowards
            (
                cannon_2.transform.rotation,
                Quaternion.FromToRotation(cannon_2.transform.position, cannon_2.transform.position + point),
                step
            );
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(GetCurrentFireTime(baseFireTime2));
        //Instantiate(perk[r], cannon_2.transform.position, Quaternion.identity);
        data.fuel2 -= shootCost2;
        step = 0;
        shooting2 = false;
    }

    void Update()
    {
        data.fuel1 = math.min(data.fuel1, GetCurrentMaxFuel(baseMaxFuel1));
        data.fuel2 = math.min(data.fuel2, GetCurrentMaxFuel(baseMaxFuel2));

        if (shoot1 && data.fuel1 > shootCost1)
        {
            if (!shooting1)
            {
                StartCoroutine(cannon1());
            }
        }
        if (shoot2 && data.fuel2 > shootCost2)
        {
            if (!shooting2)
            {
                StartCoroutine(cannon2());
            }
        }
    }

}