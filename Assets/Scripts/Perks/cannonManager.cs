using UnityEngine;
using System.Collections;
using Unity.Mathematics;

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

    public int getmaxFuel1() => GetCurrentMaxFuel(baseMaxFuel1);
    public int getmaxFuel2() => GetCurrentMaxFuel(baseMaxFuel2);

    IEnumerator cannon1()
    {
        shooting1 = true;

        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        int r = UnityEngine.Random.Range(0, perk.Length);

        Vector3 point = new Vector3(x, y, 0);

        Vector3 direction = point - cannon_1.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        while (Quaternion.Angle(cannon_1.transform.rotation, targetRotation) > 0.5f)
        {
            cannon_1.transform.rotation = Quaternion.RotateTowards(
                cannon_1.transform.rotation,
                targetRotation,
                Time.deltaTime * 300f
            );

            yield return null;
        }

        yield return new WaitForSeconds(GetCurrentFireTime(baseFireTime1));

        Instantiate(perk[r], cannon_1.transform.position, cannon_1.transform.rotation);

        data.fuel1 -= shootCost1;

        shooting1 = false;
    }

    IEnumerator cannon2()
    {
        shooting2 = true;

        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        int r = UnityEngine.Random.Range(0, perk.Length);

        Vector3 point = new Vector3(x, y, 0);

        Vector3 direction = point - cannon_2.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        while (Quaternion.Angle(cannon_2.transform.rotation, targetRotation) > 0.5f)
        {
            cannon_2.transform.rotation = Quaternion.RotateTowards(
                cannon_2.transform.rotation,
                targetRotation,
                Time.deltaTime * 300f
            );

            yield return null;
        }

        yield return new WaitForSeconds(GetCurrentFireTime(baseFireTime2));

        Instantiate(perk[r], cannon_2.transform.position, cannon_2.transform.rotation);

        data.fuel2 -= shootCost2;

        shooting2 = false;
    }

    void Start()
    {
        shoot1 = data.cannon1;
        shoot2 = data.cannon2;
    }

    void Update()
    {
        shoot1 = data.cannon1;
        shoot2 = data.cannon2;

        data.fuel1 = Mathf.Clamp(data.fuel1, 0, GetCurrentMaxFuel(baseMaxFuel1));
        data.fuel2 = Mathf.Clamp(data.fuel2, 0, GetCurrentMaxFuel(baseMaxFuel2));

        if (shoot1 && data.fuel1 > shootCost1 && !shooting1)
        {
            StartCoroutine(cannon1());
        }

        if (shoot2 && data.fuel2 > shootCost2 && !shooting2)
        {
            StartCoroutine(cannon2());
        }
    }
}