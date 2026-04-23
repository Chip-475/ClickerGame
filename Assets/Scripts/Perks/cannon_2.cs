using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using Unity.VisualScripting;

public class cannon_2 : MonoBehaviour
{
    public bool shoot2;
    public GameObject cannon2, shootPoint;
    public int shootCost2;
    public float step;

    [Header("fire rate")]
    public float baseFireTime = 1f;
    public float fireRateReductionPerLevel = 0.05f;

    [Header("depot")]
    public int baseMaxFuel1 = 100;
    public int depotBonusPerLevel = 25;

    public GameObject[] perk = new GameObject[0];

    private bool shooting2;

    IEnumerator _cannon1()
    {
        shooting2 = true;

        int x = UnityEngine.Random.Range(-500, 500);
        int y = 50;
        int r = UnityEngine.Random.Range(0, perk.Length);

        Quaternion targetRotation = Quaternion.FromToRotation(cannon2.transform.position, new Vector3(x, y, 0));

        while (cannon2.transform.rotation != targetRotation)
        {
            cannon2.transform.rotation = Quaternion.RotateTowards
            (
                cannon2.transform.rotation,
                targetRotation,
                step
            );
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(baseFireTime - (fireRateReductionPerLevel * data.cannonFireRatelvl));

        Instantiate(perk[r], shootPoint.transform.position, Quaternion.identity, shootPoint.transform);

        yield return new WaitForSeconds(7.5f);

        data.fuel1 -= shootCost2;

        shooting2 = false;
    }

    private void Start()
    {
        step = Time.deltaTime * 15f;
    }

    void Update()
    {
        shoot2 = data.cannon2;

        data.fuel1 = Mathf.Clamp(data.fuel1, 0, 100 + (data.cannonDepotlvl * 10));

        if (shoot2 && data.fuel1 > shootCost2 && !shooting2)
        {
            StartCoroutine(_cannon1());
        }

    }
}
