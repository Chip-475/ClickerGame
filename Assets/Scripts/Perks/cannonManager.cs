using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class cannonManager : MonoBehaviour
{
    public bool shoot1, shoot2;
    public GameObject cannon_1, cannon_2;
    public int shootCost1, shootCost2;

    [Header("fire rate")]
    public float baseFireTime = 1f;
    public float fireRateReductionPerLevel = 0.05f;

    [Header("depot")]
    public int baseMaxFuel1 = 100;
    public int baseMaxFuel2 = 100;
    public int depotBonusPerLevel = 25;

    public GameObject[] perk = new GameObject[0];

    private bool shooting1, shooting2;

    IEnumerator cannon1()
    {
        shooting1 = true;

        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        int r = UnityEngine.Random.Range(0, perk.Length);

        Quaternion targetRotation = Quaternion.FromToRotation(cannon_1.transform.position, new Vector3(x, y, 0));

        while (cannon_1.transform.rotation != targetRotation)
        {
            cannon_1.transform.rotation = Quaternion.RotateTowards
            (
                cannon_1.transform.rotation,
                targetRotation,
                Time.deltaTime * 15f
            );
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(baseFireTime - (fireRateReductionPerLevel * data.cannonFireRatelvl));

        Instantiate(perk[r], cannon_1.transform.position, cannon_1.transform.rotation);

        data.fuel1 -= shootCost1;

        shooting1 = false;
    }

    IEnumerator cannon2()
    {
        shooting1 = true;

        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        int r = UnityEngine.Random.Range(0, perk.Length);

        Quaternion targetRotation = Quaternion.FromToRotation(cannon_2.transform.position, new Vector3(x, y, 0));

        while (cannon_2.transform.rotation != targetRotation)
        {
            cannon_2.transform.rotation = Quaternion.RotateTowards
            (
                cannon_2.transform.rotation,
                targetRotation,
                Time.deltaTime * 15f
            );
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(baseFireTime - (fireRateReductionPerLevel * data.cannonFireRatelvl));

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

        data.fuel1 = Mathf.Clamp(data.fuel1, 0, 100 + (data.cannonDepotlvl * 10));
        data.fuel2 = Mathf.Clamp(data.fuel2, 0, 100 + (data.cannonDepotlvl * 10));

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